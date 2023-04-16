using APP_FIRTEL.Clases;
using APP_FIRTEL.ViewModels;
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
    public partial class FormRecojo : ContentPage
    {
       
        public FormRecojo(RecojoCLS objeto)
        {

            InitializeComponent();


            //lista = new List<string>();
            //lista.Add("Pendiente");
            //lista.Add("Realizado");
            //lista.Add("Ingresado");
            //defecto = "Pendiente";
            //combolista.BindingContext = lista;
            BindingContext = new FormRecojoModel(Navigation, objeto);
            //         combolista.SetBinding(Picker.ItemsSourceProperty, ".");
            //         combolista.BindingContext = defecto;
            //         //combolista.SetBinding(Picker.ItemsSourceProperty, ".");
            //         combolista.SetBinding(Picker.SelectedItemProperty, ".");
            //         combolista.ItemDisplayBinding = new Binding("Name");
            //.ItemDisplayBinding = new Binding("Name");
            //         picker.SetBinding(Picker.ItemsSourceProperty, "Monkeys");
            //         defecto = "Pendiente";
            //         BindingContext = this

            //         BindingContext = defecto;


        }

       

        private async void imgmaps_Clicked_1(object sender, EventArgs e)
        { 
            try
            {
                char delimitador = ',';
                string nombrecliente = txtnombre.Text;
                //+ " " + txtnombresegundo.Text + " " + txtapellido.Text;
                string coordenadas = txtcoordenadas.Text.Trim();
                string[] valores = coordenadas.Split(delimitador);
                if (!Double.TryParse(valores[0], out double lat))
                {
                    await DisplayAlert("Error", "Coordenadas Incorrectas", "Cancelar");
                    return;
                }
                if (!Double.TryParse(valores[1], out double longi))
                {
                    await DisplayAlert("Error", "Coordenadas Incorrectas", "Cancelar");
                    return;
                }


                var location = new Xamarin.Essentials.Location(lat, longi);
                var options = new MapLaunchOptions
                {
                    Name = nombrecliente,
                    NavigationMode = NavigationMode.None

                };
                //Launching Maps
                await Map.OpenAsync(location, options);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Coordenadas Incorrectas", "Cancelar");

            }
        }

        //private void btnRegistrarUsuario_Clicked(object sender, EventArgs e)
        //{

        //}
    }
}