using APP_FIRTEL.Clases;
using APP_FIRTEL.Vistas;
using MiPrimeraAplicacionEnXamarinForm.Generic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Utilitarios_Firtel;
using Utilitarios_Firtel.viewmodel;
using Xamarin.Forms;

namespace APP_FIRTEL.ViewModels
{
    public class AveriaModel : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        List<AveriaCLS> _ListaAveria;
       

        #endregion
        #region CONSTRUCTOR
        public AveriaModel(INavigation navigation)
        {
            Navigation = navigation;
            Mostrarpokemon();
          


        }
        #endregion
            #region OBJETOS

       
        public List<AveriaCLS> ListaAveria
        {
            get { return _ListaAveria; }
            set
            {
                SetValue(ref _ListaAveria, value);
                OnPropertyChanged();
            }
        }
        
        #endregion
        #region PROCESOS
        public async void Mostrarpokemon()
        {
            Reply res;
            var objeto = new Paginacion { pagine = 30, skip = 0, desde ="01/01/2023", hasta ="30/01/2023", idcliente ="", idestado = "" };

            ResultadoPaginacion<AveriaCLS> objres = new ResultadoPaginacion<AveriaCLS>();

            res = await GenericLH.GetAll<Paginacion>(Constantes.url + Constantes.api_getaveria, objeto);
            if (res.result == 1)
            {
                objres = JsonConvert.DeserializeObject<ResultadoPaginacion<AveriaCLS>>(JsonConvert.SerializeObject(res.data));

            }
            objres.lista.ForEach((v) => v.fecha_registrostring = v.fecha_registro != null ? ((DateTime)v.fecha_registro).ToString("dd-MM-yyyy"):"");
             
            ListaAveria = objres.lista;
        }

        #endregion
        #region PROCESOS
        public async Task IraFiltroAveria()
        {
            await Navigation.PushAsync(new FiltrosAveria());
        }
        public async Task Iradetalle(AveriaCLS parametros)
        {
            await Navigation.PushAsync(new FormAveria(parametros));
        }
       
            //_listaestado.Add(new Eestadosaveria() { idestado = 1, descripcion = "Pendiente" });
            //_listaestado.Add(new Eestadosaveria() { idestado = 2, descripcion = "Proceso" });
            //_listaestado.Add(new Eestadosaveria() { idestado = 3, descripcion = "Realizado" });

        

        #endregion
        #region COMANDOS
        public ICommand IraFiltrocommand => new Command(async () => await IraFiltroAveria());
        public ICommand Iradetallecommand => new Command<AveriaCLS>(async (p) => await Iradetalle(p));

        #endregion
    }
}
