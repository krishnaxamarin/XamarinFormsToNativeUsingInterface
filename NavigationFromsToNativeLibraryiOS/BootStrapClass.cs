using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NavigationFromsToNative;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace NavigationFromsToNativeLibraryiOS
{
    public class BootStrapClass : INavigationImplementation
    {
        public BootStrapClass()
        {
            if (!Xamarin.Forms.Forms.IsInitialized)
                Xamarin.Forms.Forms.Init();

            GlobalVariables.navigation = this;

            GlobalVariables.page = new MainPage();
            //GlobalVariables.navigation.PushNewScreen(new MainPage());
        }

        public void PushNewScreen()
        {
            var controller = GlobalVariables.page.CreateViewController();
            var vc = GetVisibleViewController();

            var i = controller.View;
            //var newcVcMODO = new Modo()
            if (vc.NavigationController != null)
                vc.NavigationController.PushViewController(controller, true);
            else
                vc.PresentViewController(controller, true, () => { });
        }

        UIViewController GetVisibleViewController()
        {
            UIViewController viewController = null;
            var window = UIApplication.SharedApplication.KeyWindow;


            if (window != null && window.WindowLevel == UIWindowLevel.Normal)
                viewController = window.RootViewController;

            if (viewController == null)
            {
                window = UIApplication.SharedApplication.Windows.OrderByDescending(w => w.WindowLevel).FirstOrDefault(w => w.RootViewController != null && w.WindowLevel == UIWindowLevel.Normal);
                if (window == null)
                    throw new InvalidOperationException("Could not find current view controller");
                else
                    viewController = window.RootViewController;
            }

            while (viewController.PresentedViewController != null)
                viewController = viewController.PresentedViewController;

            var navController = viewController as UINavigationController;
            if (navController != null)
                viewController = navController.ViewControllers.Last();

            return viewController;
        }
    }
}
