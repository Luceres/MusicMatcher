using System;
using MusicMatcher.Common;
using Foundation;
using ReactiveUI;
using UIKit;

namespace MusicMatcher.App.iOS
{
    public partial class MasterViewController : ReactiveTableViewController<IArtistListViewModel>
    {
        public MasterViewController(IntPtr handle) : base(handle)
        {           
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = NSBundle.MainBundle.LocalizedString("Master", "Master");

            ViewModel = MagicPresenter.CreateArtistListViewModel();

            ViewModel.LoadListCommand
                .Execute()
                .Subscribe();

            ViewModel.WhenAnyValue(vm => vm.Artists)
                     .BindTo<IArtist, SampleCell>(
                        TableView, 
                        SampleCell.CellIdentifier,
                        SampleCell.SizeHint, 
                        cell => cell.Initialize()
                     );
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "showDetail")
            {
                var indexPath = TableView.IndexPathForSelectedRow;
                var item = ViewModel.Artists[indexPath.Row];

                ((DetailViewController)segue.DestinationViewController).SetDetailItem(item);
            }
        }
    }
}

