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
    public class FormInstalacionModel : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        List<string> _listaestado = new List<string>();
        List<string> _listaplanes = new List<string>();
        public string nombrefile { get; set; }
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
        private bool _flgimggrabar;
        public bool flgimggrabar
        {
            get { return _flgimggrabar; }
            set { SetValue(ref _flgimggrabar, value); }
        }
        private bool _flgvisualiza;
        public bool flgvisualiza
        {
            get { return _flgvisualiza; }
            set { SetValue(ref _flgvisualiza, value); }
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
        public FormInstalacionModel(INavigation navigation, PostventaCLS objeto)
        {
            Navigation = navigation;
            // parametrosRecibe = objeto;
            Listaestado = cargaestado();
            Listaplanes = cargaplanes();
            //Txtfecha = DateTime.Now;
            objInstalacioncls = new PostventaCLS();
            // objInstalacioncls = objeto;
            objInstalacioncls = (PostventaCLS)objeto.Clone();
            flgindicador = false;
            if (objeto.nombrearchivo==null)
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
        public List<string> Listaplanes
        {
            get { return _listaplanes; }
            set { SetValue(ref _listaplanes, value); }

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
                return new List<string>() { "Pendiente", "Proceso", "Realizado","Cerrado"};
            else
                return new List<string>() { "Pendiente", "Proceso", "Realizado" };



        }
        public List<string> cargaplanes()
        {
            //int idtipousuario = Setings.IdTipoUsuario;
            //if (idtipousuario == 1)
                return new List<string>() { "Plan_50Mbps", "Plan_70Mbps", "Plan_100Mbps", 
                    "Plan_150Mbps" , "Plan_200Mbps","Plan_300Mbps","Plan_400Mbps","Plan_500Mbps","Plan_600Mbps","Plan_800Mbps","Plan_50Mbps+TV","Plan_70Mbps+TV","Plan_100Mbps+TV","Plan_150Mbps+TV","Plan_200Mbps+TV","Plan_300Mbps+TV","Plan_400Mbps+TV","Plan_500Mbps+TV","Plan_600Mbps+TV","Plan_800Mbps+TV","TV" };
            //else
            //    return new List<string>() { "Abierto", "En Proceso", "Terminado" };



        }
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
           


            //////ImageConverter Class convert Image object to Byte array.
            //byte[] bytes = imageg.by



        
        public async Task GrabarInstalacion(Page page)
        {


            flgindicador = true;
            try
            {
                var nombreestado = objInstalacioncls.nombreEstado;
                var nombreplan = objInstalacioncls.plancliente;
                var idestado = nombreestado == "Pendiente" ? 1 : nombreestado == "Proceso" ? 2 : nombreestado == "Realizado" ? 3 : 4;
                //AveriaCLS objeto = new AveriaCLS();
                int idplan = 0;
                switch (nombreplan)
                {
                    case "Plan_50Mbps":
                        idplan = 7;
                        break;
                    case "Plan_70Mbps":
                        idplan = 15;
                        break;
                    case "Plan_100Mbps":
                        idplan = 20;
                        break;
                    case "Plan_150Mbps":
                        idplan = 19;
                        break;
                    case "Plan_200Mbps":
                        idplan = 9;
                        break;
                    case "Plan_50Mbps+TV":
                        idplan = 14;
                        break;
                    case "Plan_70Mbps+TV":
                        idplan = 4;
                        break;
                    case "Plan_100Mbps+TV":
                        idplan = 11;
                        break;
                    case "Plan_150Mbps+TV":
                        idplan = 17;
                        break;
                    case "Plan_200Mbps+TV":
                        idplan = 21;
                        break;
                    case "Plan_300Mbps+TV":
                        idplan = 24;
                        break;
                    case "Plan_400Mbps+TV":
                        idplan = 23;
                        break;
                    case "Plan_300Mbps":
                        idplan = 25;
                        break;
                    case "Plan_400Mbps":
                        idplan = 22;
                        break;
                    case "Plan_500Mbps":
                        idplan = 26;
                        break;
                    case "Plan_500Mbps+TV":
                        idplan = 27;
                        break;
                    case "Plan_600Mbps":
                        idplan = 28;
                        break;
                    case "Plan_600Mbps+TV":
                        idplan = 29;
                        break;
                    case "Plan_800Mbps":
                        idplan = 30;
                        break;
                    case "Plan_800Mbps+TV":
                        idplan = 31;
                        break;


                    case "TV":
                        idplan = 12;
                        break;
                }

                objInstalacioncls.usu_modificacion = Setings.IdUsuario;
                objInstalacioncls.fec_modificacion = DateTime.Now;
                objInstalacioncls.flg_anulado = true;
                //objeto.fecha_registro = objaveriacls.fecha_registro;
                objInstalacioncls.flg_estado = idestado;
                objInstalacioncls.idplan = idplan;



                //crear el objeto averia que debo enviar
                Reply res;
                res = await GenericLH.Postfile<PostventaCLS>(Imgmedia, nombrefile, Constantes.url + Constantes.api_grabarpostventa, objInstalacioncls);
                if (res.result == 1)
                {
                    var resultado = await page.ShowPopupAsync(new alerta());

                    Instalacion.actualiza = true;
                    //await Application.Current.MainPage.DisplayAlert("Datos incompletos", "Seleccine una fecha", "OK");
                    await Volver();
                    flgindicador = false;

                }
                else
                {
                    flgindicador = false;
                    await Application.Current.MainPage.DisplayAlert("Error", "Error al Grabar", "Cancelar");
                }


            }
            catch (Exception ex )
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

        public ICommand GrabarInstalacionComand => new Command<Page>(async (p) => await GrabarInstalacion(p));
        //public ICommand Iradetallecommand => new Command<AveriaCLS>(async (p) => await Iradetalle(p));
        public ICommand VolverInstalacioncommand => new Command(async () => await Volver());



    }
}
