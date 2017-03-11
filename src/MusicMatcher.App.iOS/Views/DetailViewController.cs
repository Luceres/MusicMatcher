using System;
using MusicMatcher.Common;
using ReactiveUI;
using Splat;

namespace MusicMatcher.App.iOS
{
    public partial class DetailViewController : ReactiveViewController<ISongDetailViewModel>
    {
        private readonly IMagicPresenter _presenter;

        public DetailViewController(IntPtr handle) : base(handle)
        {
            _presenter = Locator.Current.GetService<IMagicPresenter>();

            ViewModel = _presenter.CreateSongDetailViewModel();

            
        }

        public void SetDetailItem(Song song)
        {
            ViewModel.Song = song;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.OneWayBind(ViewModel, x => x.Song.Titel, x => x.detailDescriptionLabel.Text);
        }
    }
}


