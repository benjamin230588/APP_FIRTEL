using APP_FIRTEL.Alertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APP_FIRTEL.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Animacion : ContentPage
    {
        public Animacion()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var resultado = await this.ShowPopupAsync(new alerta());

            if (resultado is bool confirmado && confirmado)
            {
                await DisplayAlert("Resultado", "Has confirmado con SÍ", "OK");
            }
            else
            {
                await DisplayAlert("Resultado", "Has elegido NO", "OK");
            }
           
        }
    }
}