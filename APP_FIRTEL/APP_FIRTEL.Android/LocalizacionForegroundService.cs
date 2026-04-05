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
        private bool isRunning = false;
        private CancellationTokenSource _cts;
        private DateTime _ultimaEjecucion = DateTime.MinValue;

        public override void OnCreate()
        {
            base.OnCreate();

            // Crear el canal del servicio en Android >= Oreo
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channel = new NotificationChannel(
                    "foreground_service_channel",  // ID del canal
                    "Foreground Service",          // Nombre visible
                    NotificationImportance.High     // Mínima importancia
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
           .SetContentTitle("Firtel")
           .SetContentText("Mensaje Firtel")
           .SetSmallIcon(Resource.Drawable.ic_notification) // Tu ícono

           .SetPriority((int)NotificationPriority.High)
           .Build();



            StartForeground(1, notification);
            if (_cts == null)
            {
                _cts = new CancellationTokenSource();
                EjecutarLoop(_cts.Token);
            }
          
            return StartCommandResult.Sticky;
        }
        private async void EjecutarTarea()
        {
            // 🔥 TU LÓGICA AQUÍ
            // Debug.w ("SERVICE", "Ejecutando cada minuto: " + DateTime.Now);
            //System.Diagnostics.Debug.WriteLine("Debug VS");
            try
            {
               await GpsUsuario.Ubicacionusurio();

                System.Diagnostics.Debug.WriteLine("Debug VS EXITO" );
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
        public override void OnDestroy()
        {
            isRunning = false;
            base.OnDestroy();
        }
        private async Task EjecutarLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    var ahora = DateTime.UtcNow;

                    // 🔥 Control de tiempo (cada 10 minutos)
                    if ((ahora - _ultimaEjecucion).TotalMinutes >= 1)
                    {
                        _ultimaEjecucion = ahora;

                        // 👉 TU LÓGICA
                        await GpsUsuario.Ubicacionusurio();

                        System.Diagnostics.Debug.WriteLine("✔ Ubicación enviada: " + ahora);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("❌ Error: " + ex.Message);
                }

                // 🔥 Delay corto (IMPORTANTE)
                await Task.Delay(5000, token);
            }
        }
        public override IBinder OnBind(Intent intent) => null;
    }
}