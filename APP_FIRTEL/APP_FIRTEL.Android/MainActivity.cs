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
using Firebase.Messaging;
using Xamarin.Forms;
using Android.Media;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace APP_FIRTEL.Droid
{
    [Activity(Label = "FIbraSur", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = false, ScreenOrientation =ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //string cadena = "deee";
            //NotificationManager manager;

            //manager = (NotificationManager)AndroidApp.Context.GetSystemService(AndroidApp.NotificationService);

            //if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            //{
            //    var channelNameJava = new Java.Lang.String(channelName);
            //    var channel = new NotificationChannel(channelId, channelNameJava, NotificationImportance.High)
            //    {
            //        Description = channelDescription
            //    };
            //    manager.CreateNotificationChannel(channel);
            //}
            var soundUri = RingtoneManager.GetDefaultUri(RingtoneType.Ringtone);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channel = new NotificationChannel(
                    "default",           // ID del canal (debe coincidir con el usado en AndroidNotificationManager)
                    "General",           // Nombre visible del canal
                    NotificationImportance.High
                )
                {
                    Description = "Canal general de notificaciones"
                };

                var audioAttributes = new AudioAttributes.Builder()
                .SetUsage(AudioUsageKind.Notification)
                .SetContentType(AudioContentType.Sonification)
                .Build();
                channel.SetSound(soundUri, audioAttributes);


                var notificationManager = (NotificationManager)GetSystemService(NotificationService);
                notificationManager.CreateNotificationChannel(channel);
            }


            //NotificationCenter.CreateNotificationChannel(new NotificationChannelRequest
            //{
            //    Id = "default",
            //    Name = "General",
            //    Description = "Canal de notificaciones",
            //    Importance = NotificationImportance.High

            //});
            //if (Intent != null && Intent.Extras != null)
            //{
            //    Plugin.LocalNotification.NotificationCenter.Current.OnNotificationTapped(Intent);
            //}


            // Manejar notificación al tocarla
            //NotificationCenter.NotifyNotificationTapped(Intent);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            //var status = await Permissions.RequestAsync<Permissions.LocationAlways>();

            ////if (status == PermissionStatus.Granted)
            ////{

            ////}
           await  PedirPermisos();

            //NotificationCenter.Current.CreateNotificationChannel();
            var intent = new Intent(this, typeof(LocalizacionForegroundService));
            StartForegroundService(intent);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);



         //   string token23=FirebaseMessaging.Instance.GetToken()

            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            LoadApplication(new App());


            if (Intent?.HasExtra("Payload") == true)
            {
                string data = Intent.GetStringExtra("Payload");
                MessagingCenter.Send<object, string>(this, "NotificationTapped", data);
            }
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
        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            DetectarNotificacionYRedirigir(intent);
        }
        private void DetectarNotificacionYRedirigir(Intent intent)
        {
            if (intent?.Extras != null && intent.Extras.ContainsKey("Payload"))
            {
                string payload = intent.GetStringExtra("Payload");
                Xamarin.Forms.MessagingCenter.Send<object, string>(this, "NotificationTapped", payload);
            }
        }
        async Task PedirPermisos()
        {

           // Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }
        }
    }
}