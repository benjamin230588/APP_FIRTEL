using APP_FIRTEL.Clases;
using APP_FIRTEL.Generic;
using APP_FIRTEL.Genericos;
using APP_FIRTEL.Vistas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Utilitarios_App;
using Xamarin.Forms;

namespace APP_FIRTEL.ViewModels
{
    public class FormInstalacionModel : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        List<string> _listaestado = new List<string>();
        string selectturno;
        DateTime txtfecha;
        PostventaCLS _objinstalacioncls;
        //List<AveriaCLS> _ListaAveria;
        private bool _flgindicador;
        public bool flgindicador
        {
            get { return _flgindicador; }
            set { SetValue(ref _flgindicador, value); }
        }
        #endregion
        #region CONSTRUCTOR
        public FormInstalacionModel(INavigation navigation, PostventaCLS objeto)
        {
            Navigation = navigation;
            // parametrosRecibe = objeto;
            Listaestado = cargaestado();
            //Txtfecha = DateTime.Now;
            objInstalacioncls = new PostventaCLS();
            objInstalacioncls = objeto;
            flgindicador = false;
            // objaveriacls.nombreEstado = 
            //objaveriacls.Estado == 1 ? "Pendiente" : objaveriacls.Estado == 2 ? "Proceso" : "Realizado";
            //Selectturno = "Pendiente";
        }
        #endregion
        #region OBJETOS
        // public AveriaCLS parametrosRecibe { get; set; }
        #endregion



        public List<string> Listaestado
        {
            get { return _listaestado; }
            set { SetValue(ref _listaestado, value); }

        }

        public PostventaCLS objInstalacioncls
        {
            get { return _objinstalacioncls; }
            set { SetValue(ref _objinstalacioncls, value); }

        }



        #region PROCESOS
        public List<string> cargaestado()
        {
            int idtipousuario = Setings.IdTipoUsuario;
            if (idtipousuario == 1)
                return new List<string>() { "Pendiente", "Proceso", "Realizado", "Terminado" };
            else
                return new List<string>() { "Pendiente", "Proceso", "Realizado" };



        }
        public async Task GrabarInstalacion()
        {


            flgindicador = true;
            var nombreestado = objInstalacioncls.nombreEstado;
            var idestado = nombreestado == "Pendiente" ? 1 : nombreestado == "Proceso" ? 2 : nombreestado == "Realizado" ? 3 : 4;
            //AveriaCLS objeto = new AveriaCLS();

            objInstalacioncls.usu_creacion = 1;
            objInstalacioncls.fec_creacion = DateTime.Now;
            objInstalacioncls.flg_anulado = true;
            //objeto.fecha_registro = objaveriacls.fecha_registro;
           // objaveriacls.Estado = idestado;



            //crear el objeto averia que debo enviar
            Reply res;
            res = await GenericLH.Post<PostventaCLS>(Constantes.url + Constantes.api_grabaraveria, objInstalacioncls);
            if (res.result == 1)
            {
                Instalacion.actualiza = true;
                //await Application.Current.MainPage.DisplayAlert("Datos incompletos", "Seleccine una fecha", "OK");
                await Volver();
                flgindicador = false;

            }
            else
            {
                flgindicador = false;
                await Application.Current.MainPage.DisplayAlert("Error", "Sucedio unerror", "OK");
            }




        }
        #endregion
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }

        public ICommand GrabarInstalacionComand => new Command(async () => await GrabarInstalacion());
        //public ICommand Iradetallecommand => new Command<AveriaCLS>(async (p) => await Iradetalle(p));
        public ICommand VolverInstalacioncommand => new Command(async () => await Volver());



    }
}
