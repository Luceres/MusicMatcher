using System.Threading.Tasks;

namespace MusicMatcher.Common
{
    public interface IMediathekService
    {
        Task<Song[]> LoadAllSongsAsync();
    }
}
