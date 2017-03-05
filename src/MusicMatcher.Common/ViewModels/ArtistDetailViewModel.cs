
namespace MusicMatcher.Common
{
    internal class ArtistDetailViewModel : IArtistDetailViewModel
    {
        private readonly IArtist _artist;

        public string Name => _artist.Name;

        public ArtistDetailViewModel(IArtist artist)
        {
            _artist = artist;
        }
    }
}
