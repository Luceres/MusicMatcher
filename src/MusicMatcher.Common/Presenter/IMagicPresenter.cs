namespace MusicMatcher.Common
{
    public interface IMagicPresenter
    {
        IMediathekViewModel CreateMediathekViewModel();
        IArtistDetailViewModel CreateArtistDetailViewModel(Artist artist);
    }
}