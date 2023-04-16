using System;
using System.Collections.Generic;
using System.Text;

namespace APP_FIRTEL.Clases
{
    public class RecojoCLS
    {
        public int idrecojo { get; set; }
        public Nullable<int> idcorrelativo { get; set; }
        public Nullable<int> idcliente { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public string obsrecojo { get; set; }
        public Nullable<int> Estado { get; set; }
        public string idtiporecojo { get; set; }
        public Nullable<System.DateTime> fechaprogramada { get; set; }
        public string horaprogramada { get; set; }
        public Nullable<int> ordenprioridad { get; set; }
        public string coordenadas { get; set; }
        public string obsalta { get; set; }
        public string comentario { get; set; }
        public Nullable<decimal> cobro { get; set; }
        public string direccion { get; set; }
        public string zona { get; set; }
        public Nullable<int> iddistrito { get; set; }
        public string flg_estado { get; set; }
        public Nullable<int> idplan { get; set; }
        public Nullable<decimal> importeplan { get; set; }
        public Nullable<int> idtecnologia { get; set; }
        public string cantidadtv { get; set; }
        public bool flg_anulado { get; set; }
        public int usu_creacion { get; set; }
        public Nullable<int> usu_modificacion { get; set; }
        public System.DateTime fec_creacion { get; set; }
        public Nullable<System.DateTime> fec_modificacion { get; set; }


        public string codigocliente { get; set; }
        public string nombrecliente { get; set; }
        //public string direccioncliente { get; set; }
        public string telefono { get; set; }

        public string plancliente { get; set; }
        public string nombreEstado { get; set; }
        //public string plancliente { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
