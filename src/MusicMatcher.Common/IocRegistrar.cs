using FanShrine.Common.Data;
using Splat;

namespace FanShrine.Common
{
    public class IocRegistrar
    {
        public static void Register()
        {
            // Register a singleton instance
            Locator.CurrentMutable.RegisterConstant(new DataService(), typeof(IDataService));

            Locator.CurrentMutable.Register(() => new ArtistListViewModel(), typeof(IArtistListViewModel));
            Locator.CurrentMutable.Register(() => new ArtistDetailViewModel(), typeof(IArtistDetailViewModel));
        }
    }
}
