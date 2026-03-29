

using Android.App;
using APP_FIRTEL.Clases;
using APP_FIRTEL.Genericos;
using Firebase.Messaging;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace APP_FIRTEL.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        const string TAG = "MyFirebaseMsgService";
        AndroidNotificationManager androidNotification = new AndroidNotificationManager();
        public override void OnMessageReceived(RemoteMessage message)
        {
            IDictionary<string, string> MensajeData = message.Data;

            string Titulo = MensajeData["title"];
            string SubTitulo = MensajeData["body"];
            string clave = MensajeData["payload"];
            // Log.Debug(TAG, "From: " + message.From);
            // Log.Debug(TAG, "Notification Message Body: " + message.GetNotification().Body);
            //androidNotification.CrearNotificacionLocal(message.GetNotification().Title, message.GetNotification().Body);
            androidNotification.CrearNotificacionLocal(Titulo, SubTitulo,clave);

        }
        public override async void OnNewToken(string token)
        {
            base.OnNewToken(token);

           // Setings.idNewToken = token;
           Preferences.Set(Preferencias.idNewToken, token);
            // sedRegisterToken(token);
            // await SendTokenToServerAsync(token);
        }

        public void sedRegisterToken(string token)
        {
            //Tu código para registrar el token a tu servidor y base de datos
        }
        private async Task SendTokenToServerAsync(string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // 🔹 URL de tu API donde guardarás el token
                    string url = Constantes.url + "/Usuarios/UpdateToken";
                    int idusuario = Setings.IdUsuario;
                    // 🔹 Objeto que enviarás al servidor
                    var data = new
                    {
                        idusuario = idusuario, // o el ID del usuario logueado
                        tokenfirebase = token
                    };

                    // 🔹 Serializar a JSON
                    string json = System.Text.Json.JsonSerializer.Serialize(data);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // 🔹 Enviar POST a tu servidor
                    var response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        System.Diagnostics.Debug.WriteLine("✅ Token enviado correctamente");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"⚠️ Error al enviar token: {response.StatusCode}");
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ Excepción: {ex.Message}");
            }
        }
    }
}