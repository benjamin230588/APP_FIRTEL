using APP_FIRTEL.Clases;
using APP_FIRTEL.ViewModels;
using APP_FIRTEL.Generic;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Utilitarios_Firtel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Globalization;
using APP_FIRTEL.Genericos;
using Utilitarios_Firtel.viewmodel;

namespace APP_FIRTEL.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        // en esta pagina aplique style locales explicitos poniendole un nombre al Key
        // en el archivo app.xaml aplique un estilo global explicito porque tiene un key
        // tambien puedo aplicar style locales y globales de manera implicita sin ponerle la palabra clave key
        public LoginModel oEntityLogin { get; set; } = new LoginModel();
        public Login()
        {
            InitializeComponent();
            //var name = App.Current.Resources["name"].ToString();
            oEntityLogin.flgindicador = false;
            oEntityLogin.usuario = "admin";
            oEntityLogin.pasword="adminfirtel";
            
            BindingContext = this;
            // System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            //oEntityLogin = new LoginModel();
            //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Orange;

        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            //var response = new ResponseModel("Home/Index");
            try
            {
                //prueba123.SwitchThumbColor = Color.Yellow;
              

                Reply res;
                Acceso model = new Acceso();
                //model.usuario = txtusuario.Text;
                //model.pasword = txtpasword.Text;
                model.usuario = oEntityLogin.usuario;
                model.pasword = oEntityLogin.pasword;
                model.plataforma = 2;
                Eusuario objeto = new Eusuario();
                oEntityLogin.flgindicador = true;
                res = await GenericLH.Post<Acceso>(Constantes.url + Constantes.api_login ,model);
                if (res.result == 1)
                {
                    objeto = JsonConvert.DeserializeObject<Eusuario>(JsonConvert.SerializeObject(res.data));

                    Setings.IdUsuario = objeto.idusuario;
                    Setings.IdTipoUsuario = objeto.idperfilcab ?? 0;
                    Setings.RecordarContra = validacontra.IsToggled;

                    Application.Current.MainPage = new Pagainaprincipal();
                }
                else
                {
                    Setings.IdUsuario = 0;
                    Setings.IdTipoUsuario = 0;
                    await DisplayAlert("Error", "Contraseña o usuario incorrecto", "Cancelar");

                }

                oEntityLogin.flgindicador = false;
            }
            catch (Exception ex)
            {
                oEntityLogin.flgindicador = false;
                await DisplayAlert("Error", ex.Message , "Cancelar");
            }
              
        }

        private void validacontra_Toggled(object sender, ToggledEventArgs e)
        {
            if (validacontra.IsToggled)
            {
                validacontra.ThumbColor = Color.Red;
            }
            else
            {
                validacontra.ThumbColor = Color.White;
            }

        }
    }
}