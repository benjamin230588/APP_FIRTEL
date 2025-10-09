using Microsoft.AspNet.SignalR.Client;
using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace APP_FIRTEL.Conexion
{
    public class SignalRService
    {
        private HubConnection _connection;
        private IHubProxy _hub;
        private bool _isReconnecting;

        // Evento que notifica a los formularios
        public event Action<string> OnMensajeRecibido;
        private static SignalRService _instance;
        public static SignalRService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SignalRService();
                }
                return _instance;
            }
        }

        public async Task StartConnectionAsync()
        {
            _connection = new HubConnection("http://fibrasurperu-001-site1.etempurl.com/");
            _hub = _connection.CreateHubProxy("EnvioMensaje");

            // Escucha de mensajes
            _hub.On<string>("message", (message) =>
            {
                var notification = new NotificationRequest
                {
                    NotificationId = DateTime.Now.Minute,
                    Title = "Nuevo Pedido Atender",
                    Description = "Esta es una notificación local usando NuGet",
                    ReturningData = "Opcional: datos que regresan al tocar la notificación",
                    Schedule =
                {
                    NotifyTime = DateTime.Now.AddSeconds(2)
                },

                    Android = new Plugin.LocalNotification.AndroidOption.AndroidOptions
                    {
                        ChannelId = "default",
                        IconSmallName = new Plugin.LocalNotification.AndroidOption.AndroidIcon("icnoti"),
                        Color = new Plugin.LocalNotification.AndroidOption.AndroidColor(unchecked((int)0xFF0000FF)),

                        // 🔹 El grande (a color, aparece al desplegar la notificación)
                        //   IconLargeName = new Plugin.LocalNotification.AndroidOption.AndroidIcon("icnotifondo"),


                        AutoCancel = false,
                        Priority = NotificationPriority.High,

                        Ongoing = true,

                    }
                    //NotifyTime = DateTime.Now.AddSeconds(1) // Se dispara en 1 segundo
                };
                //Device.BeginInvokeOnMainThread(async () =>
                //{
                //    await Application.Current.MainPage.DisplayAlert("Notificación",
                //        "Se mostró mientras la app está abierta", "OK");
                //});
                NotificationCenter.Current.Show(notification);



            });

            // Manejo de reconexión
            _connection.Closed += async () =>
            {
                if (!_isReconnecting)
                {
                    _isReconnecting = true;
                    await Reconnect();
                }
            };

            try
            {
                await _connection.Start();
                Console.WriteLine("✅ Conectado a SignalR");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error de conexión: " + ex.Message);
            }
        }

        private async Task Reconnect()
        {
            while (_connection.State != ConnectionState.Disconnected)
            {
                try
                {
                    await _connection.Start();
                    _isReconnecting = false;
                    Console.WriteLine("🔄 Reconectado a SignalR");
                }
                catch
                {
                    await Task.Delay(5000); // espera 5 seg y reintenta
                }
            }
        }

        public async Task EnviarUsuarioAsync(string usuario)
        {
            if (_connection.State == ConnectionState.Connected)
            {
                await _hub.Invoke("join", usuario);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Éxito", "Conectado", "Ok");
                });
                // await Application.Current.MainPage.DisplayAlert("ss", "conectado", "ssss");
                // Console.WriteLine("⚠️ No conectado al servidor.");
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("ss", "errror", "ssss");
                });

            }
        }
        public  int validarconexion()
        {
            if (_connection.State == ConnectionState.Disconnected)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
