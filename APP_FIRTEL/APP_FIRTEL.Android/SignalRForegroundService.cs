using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using APP_FIRTEL.Conexion;
using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationPriority = Plugin.LocalNotification.NotificationPriority;

namespace APP_FIRTEL.Droid
{
    [Service]
    public class SignalRForegroundService : Service
    {

        public override void OnCreate()
        {
            base.OnCreate();

            // Crear el canal del servicio en Android >= Oreo
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channel = new NotificationChannel(
                    "foreground_service_channel",  // ID del canal
                    "Foreground Service",          // Nombre visible
                    NotificationImportance.Min     // Mínima importancia
                )
                {
                    Description = "Canal para mantener el servicio activo"
                };

                var notificationManager = (NotificationManager)GetSystemService(NotificationService);
                notificationManager.CreateNotificationChannel(channel);
            }
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            Task.Run(() => SignalRService.Instance.StartConnectionAsync());

            //var notification = new NotificationRequest
            //{
            //    NotificationId = 1000,
            //    Title = "App conectada",
            //    Description = "Escuchando mensajes en tiempo real",
            //    Android =
            //{
            //    ChannelId = "default",
            //    AutoCancel = false,
            //    Priority = NotificationPriority.High,
            //    Ongoing = true
            //}
            //};

            var notification = new NotificationCompat.Builder(this, "foreground_service_channel")
           .SetContentTitle("")
           .SetContentText("")
           .SetSmallIcon(Resource.Drawable.ic_notification) // Tu ícono
           
           .SetPriority((int)NotificationPriority.Min)
           .Build();



            StartForeground(1, notification);

            return StartCommandResult.Sticky;
        }

        public override IBinder OnBind(Intent intent) => null;

    }
}