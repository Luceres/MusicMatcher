using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicMatcher.Common.Data
{
    internal interface IDataService
    {
        Task<List<Artist>> LoadAllArtistsAsync(int slowness);

        Task<List<Song>> LoadAllSongsAsync();
    }
}