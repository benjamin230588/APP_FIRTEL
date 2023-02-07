using APP_FIRTEL.Clases;
using APP_FIRTEL.ViewModels;
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
    public partial class Averias : ContentPage
    {
        //public List<AveriaCLS> listaCategoria { get; set; }
        public List<ListaEstado> listaestado { get; set; }
        public string fechadesde { get; set; }
        public string fechahasta { get; set; }

        public static Averias instance;
        AveriaModel vm;

        public static Averias GetInstance()
        {
            if (instance == null)
            {
                return new Averias();

            }
            else return instance;
        }
        public Averias()
        {
            instance = this;
            InitializeComponent();
           
            //listaCategoria.Add(new AveriaCLS { idaveria = 2, nombre = "josue" });
            vm = new AveriaModel(Navigation);
            BindingContext = vm;
            listaestado = new List<ListaEstado>(){
                new ListaEstado () { idestado=1 , nombre="Pendiente" ,bseleccionado=true}
               
            };
            DateTime dateactual = DateTime.Now;

            //Asi obtenemos el primer dia del mes actual
            DateTime oPrimerDiaDelMes = new DateTime(dateactual.Year, dateactual.Month, 1);

            //Y de la siguiente forma obtenemos el ultimo dia del mes
            //agregamos 1 mes al objeto anterior y restamos 1 día.
            DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddMonths(1).AddDays(-1);

            fechadesde = oPrimerDiaDelMes.ToString("dd/MM/yyyy");
            fechahasta = oUltimoDiaDelMes.ToString("dd/MM/yyyy");

            this.Appearing += Averias_Appearing;


        }
        private async void Averias_Appearing(object sender, EventArgs e)
        {
            string cadenaestado = "";
            foreach (ListaEstado objCat in listaestado) cadenaestado= cadenaestado + "," + objCat.idestado;
            cadenaestado = cadenaestado.Substring(1,cadenaestado.Length-1);
                
            
            await vm.MostrarListaAverias(fechadesde,fechahasta,cadenaestado);
            //await DisplayAlert("Error", "Contraseña o usuario incorrecto", "Cancelar");
            // DroidLocationPermissionAsker.AskLocationPermission();
        }

        //private void listaaveriacol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    Navigation.PushAsync(new FormAveria());
        //}

        //private void btnfiltro_Clicked(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new FiltrosAveria());
        //}

        //private void lstCategoria_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    Navigation.PushAsync(new FormAveria());
        //}
    }
}