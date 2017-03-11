
namespace MusicMatcher.Common
{
    internal class MagicPresenter : IMagicPresenter
    {
        public IMediathekViewModel CreateMediathekViewModel()
        {
            return new MediathekViewModel();
        }

        public ISongDetailViewModel CreateSongDetailViewModel()
        {
            return new SongDetailViewModel();
        }
    }
}
