using System;
using NavigationFromsToNativeLibraryiOS;
using UIKit;

namespace NavigationFromsToNative.iOS
{
    public partial class InitialViewController : UIViewController
    {
        public InitialViewController() : base("InitialViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            
        }


        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            var i = new BootStrapClass();
            i.PushNewScreen();
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

