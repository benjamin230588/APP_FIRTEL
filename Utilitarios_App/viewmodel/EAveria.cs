using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios_App.viewmodel
{
    public class EAveria
    {
        public int idaveria { get; set; }
        public Nullable<int> idcorrelativo { get; set; }
        public Nullable<int> idcliente { get; set; }
       

        public string obsaveria { get; set; }
       
        public Nullable<int> idgrado { get; set; }
        public string idtipoaveria { get; set; }
        public Nullable<int> Estado { get; set; }
       

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> fecha_registro { get; set; }
        //public Nullable<int> Estado { get; set; }
        public Nullable<System.DateTime> fechaprogramada { get; set; }
       
        public string obsalta { get; set; }
        public string comentario { get; set; }
        public bool flg_anulado { get; set; }
        public int usu_creacion { get; set; }
        public Nullable<int> usu_modificacion { get; set; }
        public System.DateTime fec_creacion { get; set; }
        public Nullable<System.DateTime> fec_modificacion { get; set; }
        public Nullable<decimal> cobro { get; set; }
        
        public string direccion { get; set; }
        public string zona { get; set; }
        public Nullable<int> iddistrito { get; set; }
        public string flg_estado { get; set; }
        public Nullable<int> idplan { get; set; }
        public Nullable<decimal> importeplan { get; set; }
        public Nullable<int> idtecnologia { get; set; }
        public string cantidadtv { get; set; }

        //datos clientes
        public string codigocliente { get; set; }
        public string nombrecliente { get; set; }
        //public string direccioncliente { get; set; }
        public string telefono { get; set; }

        public string plancliente { get; set; }
        public string nombreEstado { get; set; }


    }

    public class Egradoaveria
    {

        public int idgrado { get; set; }
        public string descripcion { get; set; }
    }

    public class Eestadosaveria
    {

        public int idestado { get; set; }
        public string descripcion { get; set; }
        public string nombrecolor { get; set; }
    }

}
