using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace APP_FIRTEL.Clases
{
    public class ClienteCLS
    {
        //[JsonIgnore]
        //public string invento { get; set; }

        public int idcliente { get; set; }
        public Nullable<int> idcorrelativo { get; set; }
        public string codigocliente { get; set; }
        public string nombre { get; set; }
        public string nombresegundo { get; set; }
        public string apellido { get; set; }
        public string nombrecompleto { get; set; }
        public Nullable<int> nacionalidad { get; set; }
        public string docdni { get; set; }
        public string telefono { get; set; }
        public string telefono2 { get; set; }
        public string Direccion { get; set; }
        public string Zona { get; set; }
        public Nullable<int> Distrito { get; set; }
        public Nullable<int> planbw { get; set; }
        public string cantidadtv { get; set; }
        public Nullable<System.DateTime> fechaalta { get; set; }
        public string cajanap { get; set; }
        public Nullable<int> vendedor { get; set; }
        public string pppoe { get; set; }
        public string comentario { get; set; }
        public Nullable<int> tecnologia { get; set; }
        public string flg_estado { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        //[Display(Name = "To Date")]
        public Nullable<System.DateTime> fechabaja { get; set; }
        public Nullable<System.DateTime> fechacambio { get; set; }
        public Nullable<System.DateTime> fecharecojo { get; set; }
        public Nullable<decimal> importeplan { get; set; }
        public string observacion1 { get; set; }
        public string observacion2 { get; set; }
        public Nullable<bool> flg_anulado { get; set; }
        public int usu_creacion { get; set; }
        public Nullable<int> usu_modificacion { get; set; }
        public System.DateTime fec_creacion { get; set; }
        public Nullable<System.DateTime> fec_modificacion { get; set; }

    }
}
