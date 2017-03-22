using System;
using System.Reactive.Disposables;
using MusicMatcher.Common;
using Foundation;
using ReactiveUI;
using Splat;
using UIKit;

namespace MusicMatcher.App.iOS
{
    public partial class MasterViewController : ReactiveTableViewController<IMediathekViewModel>
    {
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private readonly IMagicPresenter _presenter;

        public MasterViewController(IntPtr handle) : base(handle)
        {
            _presenter = Locator.Current.GetService<IMagicPresenter>();

            ViewModel = _presenter.CreateMediathekViewModel();

            this.WhenActivated(
                disposables =>
                {
                    ViewModel.LoadSongsCommand
                        .Execute()
                        .Subscribe()
                        .DisposeWith(disposables);
                }
            );

            this.WhenActivated(
                disposables =>
                {
                    disposables(this.BindCommand(
                        ViewModel,
                        x => x.PressTeachButtonCommand,
                        x => x._teachButton));
                }
            );
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Music Matcher";
            TableView.RowHeight = UITableView.AutomaticDimension;
            TableView.EstimatedRowHeight = SampleCell.SizeHint;  

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
                var item = ViewModel.Songs[indexPath.Row];

                ((DetailViewController)segue.DestinationViewController).SetDetailItem(item);
            }
        }
    }
}

