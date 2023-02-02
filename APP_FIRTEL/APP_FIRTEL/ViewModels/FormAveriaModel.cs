using APP_FIRTEL.Clases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace APP_FIRTEL.ViewModels
{
   public class FormAveriaModel : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        //List<AveriaCLS> _ListaAveria;
        #endregion
        #region CONSTRUCTOR
        public FormAveriaModel(INavigation navigation, AveriaCLS objeto)
        {
            Navigation = navigation;
            parametrosRecibe = objeto;
        }
        #endregion
        #region OBJETOS
        public AveriaCLS parametrosRecibe { get; set; }
        #endregion




        //public async Task IraFiltroAveria()
        //{
        //    await Navigation.PushAsync(new FiltrosAveria());
        //}
        //public async Task Iradetalle(AveriaCLS parametros)
        //{
        //    await Navigation.PushAsync(new FormAveria());
        //}

        //#endregion
        //#region COMANDOS
        //public ICommand IraFiltrocommand => new Command(async () => await IraFiltroAveria());
        //public ICommand Iradetallecommand => new Command<AveriaCLS>(async (p) => await Iradetalle(p));


    }
}
