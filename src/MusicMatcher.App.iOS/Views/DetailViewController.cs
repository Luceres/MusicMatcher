using System;
using MusicMatcher.Common;
using ReactiveUI;
using Splat;

namespace MusicMatcher.App.iOS
{
    public partial class DetailViewController : ReactiveViewController<IArtistDetailViewModel>
    {
        private readonly IMagicPresenter _presenter;

        public DetailViewController(IntPtr handle) : base(handle)
        {
            _presenter = Locator.Current.GetService<IMagicPresenter>();
        }

        public void SetDetailItem(Artist artist)
        {
            ViewModel = _presenter.CreateArtistDetailViewModel(artist);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            detailDescriptionLabel.Text = ViewModel.Name;
        }
    }
}


