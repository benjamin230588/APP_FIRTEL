using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios_App.viewmodel
{
    public class Evendedor
    {
        public int idvendedor { get; set; }
        public string nombrevendedor { get; set; }
        public Nullable<bool> flg_estado { get; set; }

    }

    public class EDistrito
    {

        public int iddistrito { get; set; }
        public string nombredistrito { get; set; }
    }

    public class Eestadosclientes
    {

        public string idestado { get; set; }
        public string nombreestado { get; set; }
    }


    public class EPlanBw
    {
        public int idplan { get; set; }
        public string nombreplan { get; set; }
        public Nullable<bool> flg_estado { get; set; }

    }

    public  class ETecnologia
    {
        public int idtecnologia { get; set; }
        public string nombretecnologia { get; set; }
    }

    public  class ENacionalidad
    {
        public int idnacionalidad { get; set; }
        public string nombre { get; set; }
    }
}
