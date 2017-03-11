namespace MusicMatcher.Common
{
    public interface IMagicPresenter
    {
        IMediathekViewModel CreateMediathekViewModel();
        ISongDetailViewModel CreateSongDetailViewModel();
    }
}