using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicMatcher.Common.Data
{
    internal interface IDataService
    {
        Task<List<IArtist>> LoadAllArtistsAsync(int slowness);
    }
}