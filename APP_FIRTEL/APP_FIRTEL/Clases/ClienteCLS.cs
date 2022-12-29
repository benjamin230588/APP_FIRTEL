using System;
using System.Collections.Generic;
using System.Text;

namespace APP_FIRTEL.Clases
{
    public class ClienteCLS
    {
        public int idcliente { get; set; }
        public Nullable<int> idcorrelativo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string codigocliente { get; set; }
        public string docdni { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public bool flg_anulado { get; set; }
        public int usu_creacion { get; set; }
        public Nullable<int> usu_modificacion { get; set; }
        public System.DateTime fec_creacion { get; set; }
        public Nullable<System.DateTime> fec_modificacion { get; set; }

    }
}
