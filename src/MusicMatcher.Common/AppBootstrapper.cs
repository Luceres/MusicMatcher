using Splat;

namespace MusicMatcher.Common
{
    public class AppBootstrapper : IEnableLogger
    {
        public static void RegisterDependencies()
        {
            Locator.CurrentMutable.RegisterConstant(new MagicPresenter(), typeof(IMagicPresenter));
        }
    }
}