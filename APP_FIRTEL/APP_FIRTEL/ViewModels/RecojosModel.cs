using APP_FIRTEL.Clases;
using APP_FIRTEL.Generic;
using APP_FIRTEL.Vistas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Utilitarios_App;
using Utilitarios_App.viewmodel;
using Xamarin.Forms;

namespace APP_FIRTEL.ViewModels
{
    public class RecojosModel : BaseViewModel
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
        public RecojosModel(INavigation navigation)
        {
            Navigation = navigation;

        }
        #endregion
        #region OBJETOS


       

        #endregion
        #region PROCESOS
      

        #endregion
        #region PROCESOS
        public async Task IraFiltroRecojo()
        {
            await Navigation.PushAsync(new FiltroRecojo());
        }
        public async Task IraFormRecojo(RecojoCLS parametros)
        {
            await Navigation.PushAsync(new FormRecojo(parametros));
        }

        //_listaestado.Add(new Eestadosaveria() { idestado = 1, descripcion = "Pendiente" });
        //_listaestado.Add(new Eestadosaveria() { idestado = 2, descripcion = "Proceso" });
        //_listaestado.Add(new Eestadosaveria() { idestado = 3, descripcion = "Realizado" });



        #endregion
        #region COMANDOS
        public ICommand IrFiltroRecojocommand => new Command(async () => await IraFiltroRecojo());
        public ICommand IrFormRecojocommand => new Command<RecojoCLS>(async (p) => await IraFormRecojo(p));
       // public ICommand Irdeslizarcommand => new Command(async () => await MostrarListaAverias2());

        #endregion
    }
}
