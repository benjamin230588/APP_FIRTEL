using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            await Navigation.PushAsync(new Paginaresultado());
        }
    }
}