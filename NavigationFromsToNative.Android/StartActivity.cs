
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using NavigationFromsToNativeLibraryDroid;

namespace NavigationFromsToNative.Droid
{
    [Activity(Label = "NavigationFromsToNative", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class StartActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.mainLayout);

            var helper = new BootStrapClass(this, Resource.Id.your_placeholder);

            //RunOnUiThread(() =>
            //{
                helper.PushNewScreen();
            //});
        }


        public override void OnBackPressed()
        {
            base.OnBackPressed();
            if(SupportFragmentManager.BackStackEntryCount == 0)
            {
                base.OnBackPressed();
            }
        }
    }
}
