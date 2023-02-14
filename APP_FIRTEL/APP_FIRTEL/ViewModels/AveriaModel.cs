using APP_FIRTEL.Clases;
using APP_FIRTEL.Vistas;
using APP_FIRTEL.Generic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Utilitarios_Firtel;
using Utilitarios_Firtel.viewmodel;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace APP_FIRTEL.ViewModels
{
    public class AveriaModel : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        int variable = 0;
        //public readonly ObservableCollection<AveriaCLS> ListaAveria= new ObservableCollection<AveriaCLS>();
        public List<ListaEstado> listaestado { get; set; }
        public string fechadesde { get; set; }
        public string fechahasta { get; set; }
        private List<AveriaCLS> listaave = new List<AveriaCLS>();
        private bool _flgindicador;
        public bool flgindicador
        {
            get { return _flgindicador; }
            set { SetValue(ref _flgindicador, value); }
        }

        #endregion
        #region CONSTRUCTOR
        public AveriaModel(INavigation navigation)
        {
            Navigation = navigation;
           
        }
        #endregion
            #region OBJETOS

       
        //public ObservableCollection<AveriaCLS> ListaAveria
        //{
        //    get {}
        //    set
        //    {
        //        //SetValue(ref _ListaAveria, value);
        //        //OnPropertyChanged();
        //    }
        //}
        
        #endregion
        #region PROCESOS
        //public async Task MostrarListaAverias()
        //{
        //    Reply res;
        //    string cadenaestado = "";
        //    foreach (ListaEstado objCat in listaestado) cadenaestado = cadenaestado + "," + objCat.idestado;
        //    cadenaestado = cadenaestado.Substring(1, cadenaestado.Length - 1);
        //    var objeto = new Paginacion { pagine = 30, skip = 0, desde = fechadesde, hasta = fechahasta, idcliente ="", idestado = cadenaestado };

        //    ResultadoPaginacion<AveriaCLS> objres = new ResultadoPaginacion<AveriaCLS>();

        //    res = await GenericLH.GetAll<Paginacion>(Constantes.url + Constantes.api_getaveria, objeto);
        //    if (res.result == 1)
        //    {
        //        objres = JsonConvert.DeserializeObject<ResultadoPaginacion<AveriaCLS>>(JsonConvert.SerializeObject(res.data));

        //    }
        //   // objres.lista.ForEach((v) => v.fecha_registrostring = v.fecha_registro != null ? ((DateTime)v.fecha_registro).ToString("dd-MM-yyyy"):"");
             
        //    //listaave = objres.lista;
        //    ListaAveria = objres.lista;
        //}
        public async Task MostrarListaAverias(string desde, string hasta, string estado)
        {
            Reply res;
            var objeto = new Paginacion { pagine = 30, skip = 0, desde = desde, hasta = hasta, idcliente = "", idestado = estado };

            ResultadoPaginacion<AveriaCLS> objres = new ResultadoPaginacion<AveriaCLS>();

            res = await GenericLH.GetAll<Paginacion>(Constantes.url + Constantes.api_getaveria, objeto);
            if (res.result == 1)
            {
                objres = JsonConvert.DeserializeObject<ResultadoPaginacion<AveriaCLS>>(JsonConvert.SerializeObject(res.data));

            }
            // objres.lista.ForEach((v) => v.fecha_registrostring = v.fecha_registro != null ? ((DateTime)v.fecha_registro).ToString("dd-MM-yyyy"):"");

            //ListaAveria = objres.lista;
            //ListaAveria.Add(objres.lista[0]);
            //ListaAveria.Add(objres.lista[1]);
            //ListaAveria.Add(objres.lista[2]);
            //ListaAveria.Add(objres.lista[3]);
            //ListaAveria.Add(objres.lista[4]);
        }
        public async Task MostrarListaAverias2()
        {
            Reply res;
            string desde = "01/01/2023";
            string hasta = "02/01/2023";
            string estado = "1";
            if (variable >= 5) return;
            var objeto = new Paginacion { pagine = 30, skip = 0, desde = desde, hasta = hasta, idcliente = "", idestado = estado };

            ResultadoPaginacion<AveriaCLS> objres = new ResultadoPaginacion<AveriaCLS>();

            res = await GenericLH.GetAll<Paginacion>(Constantes.url + Constantes.api_getaveria, objeto);
            if (res.result == 1)
            {
                objres = JsonConvert.DeserializeObject<ResultadoPaginacion<AveriaCLS>>(JsonConvert.SerializeObject(res.data));

            }
            // objres.lista.ForEach((v) => v.fecha_registrostring = v.fecha_registro != null ? ((DateTime)v.fecha_registro).ToString("dd-MM-yyyy"):"");

            //ListaAveria.Add(objres.lista[0]);
            //ListaAveria.Add(objres.lista[0]);
            //ListaAveria.Add(objres.lista[0]);
            variable += 1;

        }

        #endregion
        #region PROCESOS
        public async Task IraFiltroAveria()
        {
            await Navigation.PushAsync(new FiltrosAveria());
        }
        public async Task IraFormaveria(AveriaCLS parametros)
        {
            await Navigation.PushAsync(new FormAveria(parametros));
        }
       
            //_listaestado.Add(new Eestadosaveria() { idestado = 1, descripcion = "Pendiente" });
            //_listaestado.Add(new Eestadosaveria() { idestado = 2, descripcion = "Proceso" });
            //_listaestado.Add(new Eestadosaveria() { idestado = 3, descripcion = "Realizado" });

        

        #endregion
        #region COMANDOS
        public ICommand IrFiltroAveriacommand => new Command(async () => await IraFiltroAveria());
        public ICommand IrFormaveriacommand => new Command<AveriaCLS>(async (p) => await IraFormaveria(p));
        public ICommand Irdeslizarcommand => new Command(async () => await MostrarListaAverias2());

        #endregion
    }
}
