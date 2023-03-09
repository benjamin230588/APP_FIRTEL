using System;
using System.Collections.Generic;
using System.Text;

namespace APP_FIRTEL.Clases
{
    public class Constantes
    {
        //http://pedrotorres1234-001-site1.atempurl.com/
        //public const string url = "http://192.168.1.34:45455/Login/Inicio";
        //public const string url = "http://pedrotorres1234-001-site1.atempurl.com";
       //public const string url = "http://pedrotorres1234-001-site1.atempurl.com";
       //public const string url = "http://192.168.1.34:45455";
        //public const string url = "http://192.168.0.114:45455";
        public const string url = "http://192.168.43.41:45455";

        
        // public const string urllogin = "/Login/Inicio";

        public const string api_login = "/Login/Inicio";
        public const string api_getcliente = "/Clientes/Index";
        public const string api_getaveria = "/Averias/Index";
        public const string api_getclientebusqueda = "/Clientes/Busqueda";
       // public const string api_getaveria = "/Averias/Index";
        public const string api_getmessage = "/api/Messages";
        public const string SESSION_USUARIO_PERMISOS = "UsuarioLogueadoPermisos";

        public const string api_grabaraveria = "/Averias/Grabar";


        public const string api_getpostventa = "/PostVenta/Index";
        public const string api_grabarpostventa = "/PostVenta/Grabar";
        public const string api_obtenerpostventa = "/PostVenta/ObtenerPostVenta";
        public const string api_eliminarpostventa = "/PostVenta/Eliminar";
    }
}
