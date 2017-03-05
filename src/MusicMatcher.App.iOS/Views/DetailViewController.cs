using System;
using MusicMatcher.Common;
using ReactiveUI;

namespace MusicMatcher.App.iOS
{
    public partial class DetailViewController : ReactiveViewController<IArtistDetailViewModel>
    {
        public DetailViewController(IntPtr handle) : base(handle)
        {
        }

        public void SetDetailItem(IArtist artist)
        {
            ViewModel = MagicPresenter.CreateArtistDetailViewModel(artist);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            detailDescriptionLabel.Text = ViewModel.Name;
        }
    }
}


