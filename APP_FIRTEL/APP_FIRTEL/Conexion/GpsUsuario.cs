using APP_FIRTEL.Clases;
using APP_FIRTEL.Genericos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace APP_FIRTEL.Conexion
{
    public class GpsUsuario
    {
        public int suma()
        {
            return 5;
        }
        public static async Task<Localizacion> Ubicacionusurio()
        {

            var request = new GeolocationRequest(GeolocationAccuracy.Best);
            var location = await Geolocation.GetLocationAsync(request);
            Localizacion  obj= new Localizacion();
            if (location != null)
            {
                obj.latitud = location.Latitude;
                obj.longitud= location.Longitude;
            }

            using (var client = new HttpClient())
            {
                // 🔹 URL de tu API donde guardarás el token
                string url = Constantes.url + "/Localizacion/Grabar";
                int idusuario = Preferences.Get(Preferencias.IdUsuario, 0);

                // 🔹 Objeto que enviarás al servidor
                var data = new
                {
                    idlocalizacion=0,
                    idusuario = idusuario, // o el ID del usuario logueado
                    latitud = obj.latitud,
                    longitud= obj.longitud,
                    Fecha = DateTime.UtcNow
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


            return obj;
        }
    }
}
