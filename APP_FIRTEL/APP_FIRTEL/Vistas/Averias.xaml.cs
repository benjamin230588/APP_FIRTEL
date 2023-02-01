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
        public List<AveriaCLS> listaCategoria { get; set; }
        public Averias()
        {
            InitializeComponent();
            
            //listaCategoria.Add(new AveriaCLS { idaveria = 2, nombre = "josue" });
            BindingContext = new AveriaModel(Navigation);


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