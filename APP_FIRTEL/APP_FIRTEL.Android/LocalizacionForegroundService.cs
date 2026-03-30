using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using APP_FIRTEL.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
namespace APP_FIRTEL.Droid
{
    [Service]
    public class LocalizacionForegroundService :Service
    {
        private Timer _timer;

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
            //Task.Run(() => SignalRService.Instance.StartConnectionAsync());

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

           .SetPriority((int)NotificationPriority.Low)
           .Build();



            StartForeground(1, notification);

            _timer = new Timer(EjecutarTarea, null, TimeSpan.Zero, TimeSpan.FromSeconds(20));


            return StartCommandResult.Sticky;
        }
        private async void EjecutarTarea(object state)
        {
            // 🔥 TU LÓGICA AQUÍ
            // Debug.w ("SERVICE", "Ejecutando cada minuto: " + DateTime.Now);
            //System.Diagnostics.Debug.WriteLine("Debug VS");
            try
            {
               var result = await GpsUsuario.Ubicacionusurio();

                System.Diagnostics.Debug.WriteLine("Debug VS" + result.latitud );
            }
            catch (Exception ex)
            {
                //var result = await GpsUsuario.Ubicacionusurio();

                System.Diagnostics.Debug.WriteLine("Debug VS error" );
            }
           
            //  Android.Util.Log.Debug("SERVICE", "Ejecutando cada minuto: " + result.latitud + "--" + result.longitud);
            // Ejemplo:
            // llamar API
            // guardar datos
            // obtener ubicación
        }

        public override IBinder OnBind(Intent intent) => null;
    }
}