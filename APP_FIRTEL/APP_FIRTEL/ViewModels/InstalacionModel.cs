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
    public class InstalacionModel : BaseViewModel
    {
        #region VARIABLES
        int variable = 0;
        public List<ListaEstado> listaestado { get; set; }
        public string fechadesde { get; set; }
        public string fechahasta { get; set; }
        //private List<AveriaCLS> listaave = new List<AveriaCLS>();
        private bool _flgindicador;
        public bool flgindicador
        {
            get { return _flgindicador; }
            set { SetValue(ref _flgindicador, value); }
        }

        #endregion
        #region CONSTRUCTOR
        public InstalacionModel(INavigation navigation)
        {
            Navigation = navigation;

        }
        #endregion
        #region OBJETOS


        

        #endregion
        #region PROCESOS
      
       
        

        public async Task IraFiltroInstalacion()
        {
            await Navigation.PushAsync(new FiltroInstalacion());
        }
        public async Task IraFormInstalacion(PostventaCLS parametros)
        {
            await Navigation.PushAsync(new FormInstalacion(parametros));
        }

        


        #endregion
        #region COMANDOS
        public ICommand IrFiltroInstalacioncommand => new Command(async () => await IraFiltroInstalacion());
        public ICommand IrFormInstalacioncommand => new Command<PostventaCLS>(async (p) => await IraFormInstalacion(p));
       // public ICommand Irdeslizarcommand => new Command(async () => await MostrarListaAverias2());

        #endregion


    }
}
