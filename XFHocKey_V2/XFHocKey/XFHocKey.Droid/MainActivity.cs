using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using HockeyApp.Android;
using Xamarin.Forms;

namespace XFHocKey.Droid
{
    [Activity(Label = "多奇集團 行動儀表板", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public string HocKeyApp_ID = "ee4d14e6b55d41569395c176e9720ebb";
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            // 註冊程式異常崩壞的回報機制
            CrashManager.Register(this, HocKeyApp_ID);

            // 檢查是否有新版本推出，讓使用者可以選擇是否要升級
            CheckForUpdates();

        }

        void CheckForUpdates()
        {
            // Remove this for store builds!
            UpdateManager.Register(this, HocKeyApp_ID);
        }

        void UnregisterManagers()
        {
            UpdateManager.Unregister();
        }

        protected override void OnPause()
        {
            base.OnPause();

            UnregisterManagers();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            UnregisterManagers();
        }
    }
}

