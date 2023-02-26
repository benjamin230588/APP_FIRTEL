using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios_App.viewmodel
{
    public class Eusuario
    {
        public int idusuario { get; set; }
        public Nullable<int> idcorrelativo { get; set; }
        public string Usuario { get; set; }
        public string pasword { get; set; }
        public Nullable<int> idperfilcab { get; set; }
        //public bool flg_anulado { get; set; }
        //public int usu_creacion { get; set; }
        //public Nullable<int> usu_modificacion { get; set; }
        //public System.DateTime fec_creacion { get; set; }
        //public Nullable<System.DateTime> fec_modificacion { get; set; }
    }
}
