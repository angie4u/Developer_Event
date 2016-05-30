using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;

using Android.Util;
using Gcm.Client;

namespace MyOrders.Droid
{
    [Activity(Label = "Developer Event", Icon = "@drawable/ic_launcher",
        Theme = "@android:style/Theme.Material.Light.DarkActionBar",
        MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]

    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            ActionBar.SetIcon(
                new ColorDrawable(Resources.GetColor(Android.Resource.Color.Transparent)));

            //RegisterWithGCM();

        }



        //private void RegisterWithGCM()
        //{
        //    // Check to ensure everything's set up right
        //    GcmClient.CheckDevice(this);
        //    GcmClient.CheckManifest(this);

        //    // Register for push notifications
        //    Log.Info("MainActivity", "Registering...");
        //    GcmClient.Register(this, Constants.SenderID);
        //}


    }
}

