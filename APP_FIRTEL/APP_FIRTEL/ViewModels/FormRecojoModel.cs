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
    class FormRecojoModel : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        List<string> _listaestado = new List<string>();
        string selectturno;
        DateTime txtfecha;
        RecojoCLS _objrecojocls;
        //List<AveriaCLS> _ListaAveria;
        private bool _flgindicador;

        public bool flgindicador
        {
            get { return _flgindicador; }
            set { SetValue(ref _flgindicador, value); }
        }
        #endregion
        #region CONSTRUCTOR
        public FormRecojoModel(INavigation navigation, RecojoCLS objeto)
        {
            Navigation = navigation;
            // parametrosRecibe = objeto;
            Listaestado = cargaestado();
            //Txtfecha = DateTime.Now;
            objrecojocls = new RecojoCLS();
            //myClass b = (AveriaCLS)objeto.Clone();
            objrecojocls = (RecojoCLS)objeto.Clone();
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

        public RecojoCLS objrecojocls
        {
            get { return _objrecojocls; }
            set { SetValue(ref _objrecojocls, value); }

        }



        #region PROCESOS
        public List<string> cargaestado()
        {
            int idtipousuario = Setings.IdTipoUsuario;
            if (idtipousuario == 1)
                return new List<string>() { "Pendiente", "Proceso", "Realizado", "Cerrado" };
            else
                return new List<string>() { "Pendiente", "Proceso", "Realizado" };



        }
        public async Task GrabarRecojo()
        {


            flgindicador = true;
            var nombreestado = objrecojocls.nombreEstado;
            try
            {
                var idestado = nombreestado == "Pendiente" ? 1 : nombreestado == "Proceso" ? 2 : nombreestado == "Realizado" ? 3 : 4;
                //AveriaCLS objeto = new AveriaCLS();

                objrecojocls.usu_modificacion = 1;
                objrecojocls.fec_modificacion = DateTime.Now;
                objrecojocls.flg_anulado = true;
                //objeto.fecha_registro = objaveriacls.fecha_registro;
                objrecojocls.Estado = idestado;



                //crear el objeto averia que debo enviar
                Reply res;
                res = await GenericLH.Post<RecojoCLS>(Constantes.url + Constantes.api_grabarrecojo, objrecojocls);
                if (res.result == 1)
                {
                    Recojos.actualiza = true;
                    //await Application.Current.MainPage.DisplayAlert("Datos incompletos", "Seleccine una fecha", "OK");
                    await Volver();
                    flgindicador = false;

                }
                else
                {
                    flgindicador = false;
                    await Application.Current.MainPage.DisplayAlert("Error", "Error al grabar", "Cancelar");
                }
            }
            catch (Exception ex)
            {
                flgindicador = false;
                await Application.Current.MainPage.DisplayAlert("Error", "Error de Conexion", "Cancelar");

            }





        }
        #endregion
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }

        public ICommand GrabarRecojoComand => new Command(async () => await GrabarRecojo());
        //public ICommand Iradetallecommand => new Command<AveriaCLS>(async (p) => await Iradetalle(p));
        public ICommand VolverRecojocommand => new Command(async () => await Volver());



    }
}
