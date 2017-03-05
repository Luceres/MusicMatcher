using System;
using MusicMatcher.Common;
using Foundation;
using ReactiveUI;
using Splat;
using UIKit;

namespace MusicMatcher.App.iOS
{
    public partial class MasterViewController : ReactiveTableViewController<IMediathekViewModel>
    {
        private readonly IMagicPresenter _presenter;

        public MasterViewController(IntPtr handle) : base(handle)
        {
            _presenter = Locator.Current.GetService<IMagicPresenter>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Music Matcher";
            TableView.RowHeight = UITableView.AutomaticDimension;
            TableView.EstimatedRowHeight = SampleCell.SizeHint;

            ViewModel = _presenter.CreateMediathekViewModel();

            ViewModel.LoadSongsCommand
                .Execute()
                .Subscribe();

            ViewModel
                .WhenAnyValue(vm => vm.Songs)
                .BindTo<Song, SampleCell>(
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

