using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Plugin.CurrentActivity;
using Plugin.Permissions;
using Plugin.LocalNotification.Platform.Droid;
using Plugin.LocalNotification;
using Android.Content;

namespace APP_FIRTEL.Droid
{
    [Activity(Label = "FIbraSur", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = false, ScreenOrientation =ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            NotificationCenter.CreateNotificationChannel(new NotificationChannelRequest
            {
                Id = "default",
                Name = "General",
                Description = "Canal de notificaciones",
                Importance = NotificationImportance.High
                
            });
            //if (Intent != null && Intent.Extras != null)
            //{
            //    Plugin.LocalNotification.NotificationCenter.Current.OnNotificationTapped(Intent);
            //}


            // 🔔 Manejar notificación al tocarla
             NotificationCenter.NotifyNotificationTapped(Intent);
            var intent = new Intent(this, typeof(SignalRForegroundService));
            StartForegroundService(intent);
            //NotificationCenter.Current.CreateNotificationChannel();


            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);




            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        //protected override void OnNewIntent(Intent intent)
        //{
        //    base.OnNewIntent(intent);

        //    // Esto es clave para que la notificación funcione aunque la app esté abierta
        //    Plugin.LocalNotification.NotificationCenter.Current.NotifyNotificationTapped(intent);
        //}
        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        //{
        //    Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}