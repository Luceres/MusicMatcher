using Foundation;
using ReactiveUI;
using UIKit;

namespace MusicMatcher.App.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations
        public override UIWindow Window { get; set; }
        private readonly AutoSuspendHelper _autoSuspendHelper;

        public AppDelegate()
        {
            AppBootstrapper.RegisterDependencies();

            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            RxApp.SuspensionHost.CreateNewAppState = () => new AppState();
            RxApp.SuspensionHost.SetupDefaultSuspendResume();

            _autoSuspendHelper = new AutoSuspendHelper(this);
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            _autoSuspendHelper.FinishedLaunching(application, launchOptions);
            return true;
        }

        public override void OnActivated(UIApplication application)
        {
            _autoSuspendHelper.OnActivated(application);
        }

        public override void DidEnterBackground(UIApplication application)
        {
            _autoSuspendHelper.DidEnterBackground(application);
        }
    }
}


