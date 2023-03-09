using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APP_FIRTEL.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Paginaopciones : ContentPage
    {
        public Paginaopciones()
        {
            InitializeComponent();
        }

        private async void btnopciones_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new Paginaresultado());
            string cadena = "12.23rrr3";
            double numero=123.45;
            bool resu = Double.TryParse(cadena, out numero);
            var location = new Location(-12.096379642493742, -76.98385251539655);
            var options = new MapLaunchOptions { Name = "Disney World",
                                                NavigationMode=NavigationMode.None
            
            };
            //Launching Maps
            await Map.OpenAsync(location, options);
        }
    }
}