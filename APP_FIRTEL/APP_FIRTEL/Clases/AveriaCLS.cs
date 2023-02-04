using System;
using System.Collections.Generic;
using System.Text;

namespace APP_FIRTEL.Clases
{
    public class AveriaCLS
    {
        public int idaveria { get; set; }
        public Nullable<int> idcorrelativo { get; set; }
        public Nullable<int> idcliente { get; set; }


        public string obsaveria { get; set; }

        public Nullable<int> idgrado { get; set; }
        public string nombregrado { get; set; }
        public string idtipoaveria { get; set; }
        public Nullable<int> Estado { get; set; }
        public string nombreEstado { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public string fecha_registrostring { get; set; }
        //public Nullable<int> Estado { get; set; }
        public Nullable<System.DateTime> fechaprogramada { get; set; }

        public string obsalta { get; set; }
        public string comentario { get; set; }
        public bool flg_anulado { get; set; }
        public int usu_creacion { get; set; }
        public Nullable<int> usu_modificacion { get; set; }
        public System.DateTime fec_creacion { get; set; }
        public Nullable<System.DateTime> fec_modificacion { get; set; }

        //datos clientes
        public string codigocliente { get; set; }
        public string nombrecliente { get; set; }
        public string direccioncliente { get; set; }
        public string telefono { get; set; }
        public string plancliente { get; set; }
        //public int idaveria { get; set; }
        //public string nombre { get; set; }
        //public string direccion { get; set; }
        //public string cliente { get; set; }
        //public string estado { get; set; }
        //public string fecha { get; set; }

        //public int idtecnico { get; set; }
        //public string nombretecnico { get; set; }


    }
}
