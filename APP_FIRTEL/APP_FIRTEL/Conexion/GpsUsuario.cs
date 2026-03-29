using APP_FIRTEL.Clases;
using System;
using System.Collections.Generic;
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
            return obj;
        }
    }
}
