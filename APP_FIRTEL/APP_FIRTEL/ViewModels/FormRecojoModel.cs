using APP_FIRTEL.Alertas;
using APP_FIRTEL.Clases;
using APP_FIRTEL.Generic;
using APP_FIRTEL.Genericos;
using APP_FIRTEL.Vistas;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Utilitarios_App;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace APP_FIRTEL.ViewModels
{
    public class FormRecojoModel : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        List<string> _listaestado = new List<string>();
        public string nombrefile { get; set; }
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

        public int _alto;

        public int alto
        {
            get { return _alto; }
            set { SetValue(ref _alto, value); }
        }
        private int _ancho;
        public int ancho
        {
            get { return _ancho; }
            set { SetValue(ref _ancho, value); }
        }
        private ImageSource _Imagenpost;
        public ImageSource Imagenpost
        {
            get { return _Imagenpost; }
            set { SetValue(ref _Imagenpost, value); }
        }
        private MediaFile _Imgmedia;
        public MediaFile Imgmedia
        {
            get { return _Imgmedia; }
            set { SetValue(ref _Imgmedia, value); }
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
            if (objeto.nombrearchivo == null)
            {
                alto = 150;
                ancho = 330;

            }
            else
            {
                alto = 300;
                ancho = 330;
                traebytes(objeto.rutaarchivo);
            }
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
        public async Task GrabarRecojo(Page page)
        {


            flgindicador = true;
            var nombreestado = objrecojocls.nombreEstado;
            try
            {
                var idestado = nombreestado == "Pendiente" ? 1 : nombreestado == "Proceso" ? 2 : nombreestado == "Realizado" ? 3 : 4;
                //AveriaCLS objeto = new AveriaCLS();

                objrecojocls.usu_modificacion = Setings.IdUsuario;
                objrecojocls.fec_modificacion = DateTime.Now;
                objrecojocls.flg_anulado = true;
                //objeto.fecha_registro = objaveriacls.fecha_registro;
                objrecojocls.Estado = idestado;



                //crear el objeto averia que debo enviar
                Reply res;
              //  res = await GenericLH.Post<RecojoCLS>(Constantes.url + Constantes.api_grabarrecojo, objrecojocls);
                res = await GenericLH.Postfile<RecojoCLS>(Imgmedia, nombrefile, Constantes.url + Constantes.api_grabarrecojo, objrecojocls);

                if (res.result == 1)
                {
                    var resultado = await page.ShowPopupAsync(new alerta());

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

        public ICommand GrabarRecojoComand => new Command<Page>(async (p) => await GrabarRecojo(p));
        //public ICommand Iradetallecommand => new Command<AveriaCLS>(async (p) => await Iradetalle(p));
        public ICommand VolverRecojocommand => new Command(async () => await Volver());

        public async void traebytes(string url)
        {
            byte[] bytes;

            using (HttpClient client = new HttpClient())
            {
                byte[] fileArray = await client.GetByteArrayAsync(url);
                bytes = fileArray;
            }
            Imagenpost = ImageSource.FromStream(() => new MemoryStream(bytes));

        }


    }
}
