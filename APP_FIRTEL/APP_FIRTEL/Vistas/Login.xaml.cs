using APP_FIRTEL.Clases;
using APP_FIRTEL.ViewModels;
using MiPrimeraAplicacionEnXamarinForm.Generic;
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

namespace APP_FIRTEL.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public LoginModel oEntityLogin { get; set; } = new LoginModel();
        public Login()
        {
            InitializeComponent();
            oEntityLogin.flgindicador = false;
             //oEntityLogin = new LoginModel();
            BindingContext = this;
            //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Orange;

        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            //var response = new ResponseModel("Home/Index");
            try
            {
                Reply res;
                Acceso model = new Acceso();
                model.usuario = txtusuario.Text;
                model.pasword = txtpasword.Text;
                oEntityLogin.flgindicador = true;
                res = await GenericLH.Post<Acceso>(Constantes.urllogin ,model);
                if (res.result == 1)
                {
                    Application.Current.MainPage = new Pagainaprincipal();
                }
                else
                {
                    await DisplayAlert("Error", "Contraseña o usuario incorrecto", "Cancelar");

                }

                oEntityLogin.flgindicador = false;
            }
            catch (Exception ex)
            {
                oEntityLogin.flgindicador = false;
                await DisplayAlert("Error", "Error Producido", "Cancelar");
            }
               
           




        }

        
    }
}