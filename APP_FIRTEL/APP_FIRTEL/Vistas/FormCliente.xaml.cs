using APP_FIRTEL.Clases;
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
    public partial class FormCliente : ContentPage
    {
        public ClienteCLS objcliente { get; set; } = new ClienteCLS();
        
        public string titulo { get; set; }

        public FormCliente(ClienteCLS obj, string nombretitulo)
        {
           
            InitializeComponent();       
            objcliente = obj;       
            titulo = nombretitulo;
           
            BindingContext = this;
            //dtfecha.NullableDate = null;


        }

        private async void btnvolvercliente_Clicked(object sender, EventArgs e)
        {
            // var prueba =cmboestado23.SelectedItem;
            await Navigation.PopAsync();
        }
    }
}