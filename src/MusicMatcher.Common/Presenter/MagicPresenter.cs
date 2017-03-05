
namespace MusicMatcher.Common
{
    public class MagicPresenter
    {
        public static IArtistListViewModel CreateArtistListViewModel()
        {
            return new ArtistListViewModel();
        }

        public static IArtistDetailViewModel CreateArtistDetailViewModel(IArtist artist)
        {
            return new ArtistDetailViewModel(artist);
        }
    }
}
