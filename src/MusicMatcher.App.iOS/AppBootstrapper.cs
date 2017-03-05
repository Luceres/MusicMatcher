using MusicMatcher.Common;
using Splat;

namespace MusicMatcher.App.iOS
{
    public class AppBootstrapper : IEnableLogger
    {
        public static void RegisterDependencies()
        {
            Common.AppBootstrapper.RegisterDependencies();

            Locator.CurrentMutable.RegisterConstant(new MediathekService(), typeof(IMediathekService));
        }
    }
}