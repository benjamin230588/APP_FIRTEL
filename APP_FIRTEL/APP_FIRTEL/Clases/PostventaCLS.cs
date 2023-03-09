using System;
using System.Collections.Generic;
using System.Text;

namespace APP_FIRTEL.Clases
{
    public class PostventaCLS
    {
        public int idpostventa { get; set; }
        public Nullable<int> idpreventa { get; set; }

        public Nullable<int> idcorrelativo { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public string nombre { get; set; }
        public string nombresegundo { get; set; }
        public string apellido { get; set; }

        public string dni { get; set; }
        public string direccion { get; set; }
        public string zona { get; set; }
        public Nullable<int> idplan { get; set; }
        public string celular { get; set; }
        public Nullable<decimal> importeinstalacion { get; set; }
        public string coordenadas { get; set; }
        public Nullable<int> condiciondomicilio { get; set; }
        public Nullable<int> flg_estado { get; set; }
        public Nullable<bool> flg_anulado { get; set; }
        public int usu_creacion { get; set; }
        public Nullable<int> usu_modificacion { get; set; }
        public System.DateTime fec_creacion { get; set; }
        public Nullable<System.DateTime> fec_modificacion { get; set; }
        public string observacion { get; set; }
        public string plancliente { get; set; }
        public string nombreEstado { get; set; }
        public string nombrecliente { get; set; }
    }
}
