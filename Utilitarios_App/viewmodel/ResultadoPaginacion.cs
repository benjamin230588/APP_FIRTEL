using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios_App.viewmodel
{
    public class ResultadoPaginacion<T>
    {
        public int cantidadregistro { get; set; }
        public List<T> lista {get;set;}
    }
}
