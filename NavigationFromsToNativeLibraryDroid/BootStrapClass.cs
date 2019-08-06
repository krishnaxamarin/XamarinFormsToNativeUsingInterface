using System;
using Android.App;
using Android.Runtime;
using Android.Support.V7.App;
using Java.Interop;
using NavigationFromsToNative;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace NavigationFromsToNativeLibraryDroid
{
    [Register("hellosharedui.droid.UIHelpers")]
    public class BootStrapClass : Java.Lang.Object, INavigationImplementation
    {
        AppCompatActivity appCompatActivity;
        int layoutID;

        public BootStrapClass(AppCompatActivity _appCompatActivity, int _layoutID ) : base()
        {
            appCompatActivity = _appCompatActivity;
            layoutID = _layoutID;
            GlobalVariables.page = new MainPage();
            GlobalVariables.navigation = this;
        }

        public BootStrapClass(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {

        }

        [Export("pushNewScreen")]
        public void PushNewScreen()
        {
            if (!Forms.IsInitialized)
                Forms.Init(appCompatActivity, null);

            var ft = appCompatActivity.SupportFragmentManager.BeginTransaction();
            var temp = GlobalVariables.page.CreateSupportFragment(appCompatActivity);
            ft.Replace(layoutID, temp);
            ft.AddToBackStack(null).Commit();


        }
    }
}
