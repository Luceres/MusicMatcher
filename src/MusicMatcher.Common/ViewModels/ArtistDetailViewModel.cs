
namespace MusicMatcher.Common
{
    internal class ArtistDetailViewModel : IArtistDetailViewModel
    {
        private readonly Artist _artist;

        public string Name => _artist.Name;

        public ArtistDetailViewModel(Artist artist)
        {
            _artist = artist;
        }
    }
}
