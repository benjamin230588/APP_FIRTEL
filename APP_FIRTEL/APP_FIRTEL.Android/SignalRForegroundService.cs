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

            var notification = new NotificationCompat.Builder(this, "default")
           .SetContentTitle("App conectada")
           .SetContentText("Escuchando mensajes en tiempo real")
           .SetSmallIcon(Resource.Drawable.ic_notification) // Tu ícono
           .SetOngoing(true)
           .SetPriority((int)NotificationPriority.High)
           .Build();



            StartForeground(1, notification);

            return StartCommandResult.Sticky;
        }

        public override IBinder OnBind(Intent intent) => null;

    }
}