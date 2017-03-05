
namespace MusicMatcher.Common
{
    internal class MagicPresenter : IMagicPresenter
    {
        public IMediathekViewModel CreateMediathekViewModel()
        {
            return new MediathekViewModel();
        }

        public IArtistDetailViewModel CreateArtistDetailViewModel(Artist artist)
        {
            return new ArtistDetailViewModel(artist);
        }
    }
}
