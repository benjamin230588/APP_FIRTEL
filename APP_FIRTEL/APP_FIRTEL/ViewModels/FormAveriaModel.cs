using APP_FIRTEL.Clases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Utilitarios_Firtel.viewmodel;
using Xamarin.Forms;

namespace APP_FIRTEL.ViewModels
{
   public class FormAveriaModel : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        List<Eestadosaveria> _listaestado = new List<Eestadosaveria>();
        //List<AveriaCLS> _ListaAveria;
        #endregion
        #region CONSTRUCTOR
        public FormAveriaModel(INavigation navigation, AveriaCLS objeto)
        {
            Navigation = navigation;
            parametrosRecibe = objeto;
            Listaestado = cargaestado();
        }
        #endregion
        #region OBJETOS
        public AveriaCLS parametrosRecibe { get; set; }
        #endregion



        public List<Eestadosaveria> Listaestado
        {
            get { return _listaestado; }
            set { SetValue(ref _listaestado, value); }

        }
        public List<Eestadosaveria> cargaestado()
        {
            return new List<Eestadosaveria>()
            {
               new Eestadosaveria() { idestado = 1, descripcion = "Pendiente" },
               new Eestadosaveria() { idestado = 2, descripcion = "Proceso" },
               new Eestadosaveria() { idestado = 3, descripcion = "Realizado" }
            };

        }
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
