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
    public partial class Paginainicio : ContentPage
    {
        public bool oEntityLogin { get; set; }
        public Paginainicio()
        {
            InitializeComponent();
            oEntityLogin = false;
            BindingContext = this;
        }

        //private async void btninicio_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Paginaopciones());
        //}

        private void btndale_Clicked(object sender, EventArgs e)
        {
            var inicio = 20;
            var estado = oEntityLogin;


        }
    }
}