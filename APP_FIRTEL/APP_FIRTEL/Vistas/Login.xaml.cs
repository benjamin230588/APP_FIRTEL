using APP_FIRTEL.Clases;
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
        public LoginCLS ousuarioCLS { get; set; } = new LoginCLS();
        public Login()
        {
            InitializeComponent();
            ousuarioCLS.flgindicadormetodo = false;
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
                ousuarioCLS.flgindicadormetodo = true;
                res = await Post<Acceso>(Constantes.urllogin ,model);
                if (res.result == 1)
                {
                    Application.Current.MainPage = new Pagainaprincipal();
                }
                else
                {
                    DisplayAlert("Error", "Contraseña o usuario incorrecto", "Cancelar");

                }

                ousuarioCLS.flgindicadormetodo = false;
            }
            catch (Exception ex)
            {
                ousuarioCLS.flgindicadormetodo = false;
            }
               
            //var restResponse = Restcall.MakeRequest(Constantes.url + Constantes.api_login, Method.POST, null, model);
            //if (restResponse.StatusCode == HttpStatusCode.OK)
            //{

            //    res = JsonConvert.DeserializeObject<Reply>(restResponse.Content);
            //    if (res.result == 1)
            //    {
            //        Application.Current.MainPage = new Pagainaprincipal();
            //    }
            //    else
            //    {
            //        DisplayAlert("Error", "Contraseña o usuario incorrecto", "Cancelar");

            //    }

            //}
            //else
            //{
            //    response.success = false;
            //    response.error = "usuario no encontrado";

            //}


            //return Json(response);




        }

        public  async Task<Reply> Post<T>(string url, T obj)
        {
            HttpClient cliente = new HttpClient();
            var cadena = JsonConvert.SerializeObject(obj);
            var body = new StringContent(cadena, Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync(url, body);
            if (!response.IsSuccessStatusCode) return new Reply { result = 0 };
            else
            {
                //int respuesta = int.Parse(await response.Content.ReadAsStringAsync());
                var result = await response.Content.ReadAsStringAsync();
                Reply res = JsonConvert.DeserializeObject<Reply>(result);
                return res;
            }


        }
    }
}