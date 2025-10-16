using APP_FIRTEL.Clases;
using APP_FIRTEL.Genericos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace APP_FIRTEL.Firebase
{
    public class ServiceFireToken
    {
        public async Task SendTokenToServerAsync(string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // 🔹 URL de tu API donde guardarás el token
                    string url = Constantes.url + "/Usuarios/UpdateToken";
                    int idusuario = Preferences.Get(Preferencias.IdUsuario, 0);

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
