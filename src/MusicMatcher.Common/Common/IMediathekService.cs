using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicMatcher.Common
{
    public interface IMediathekService
    {
        Task<IEnumerable<Song>> ReadAllSongsAsync();
    }
}
