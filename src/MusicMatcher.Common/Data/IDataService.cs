using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicMatcher.Common.Data
{
    internal interface IDataService
    {
        Task<IEnumerable<Artist>> LoadAllArtistsAsync(int slowness);

        Task<IEnumerable<Song>> LoadAllSongsAsync();
    }
}