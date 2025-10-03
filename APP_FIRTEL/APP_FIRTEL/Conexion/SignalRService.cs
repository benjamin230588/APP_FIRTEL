using Microsoft.AspNet.SignalR.Client;
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
                // Solo disparamos el evento
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Notificación",
                        message, "OK");
                });


                
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
            while (_connection.State != ConnectionState.Connected)
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
    }
}
