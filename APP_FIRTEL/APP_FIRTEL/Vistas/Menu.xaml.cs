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
    public partial class Menu : ContentPage
    {
        public List<MenuCLS> listamenu { get; set; }
        public Menu()
        {
            InitializeComponent();
            listamenu = new List<MenuCLS>();
            listamenu.Add(new MenuCLS { nombreicono = "ic_categoria", nombreitem = "Averias" });
            listamenu.Add(new MenuCLS { nombreicono = "ic_producto", nombreitem = "Instalaciones" });
            listamenu.Add(new MenuCLS { nombreicono = "ic_producto", nombreitem = "Clientes" });
            listamenu.Add(new MenuCLS { nombreicono = "ic_cerrar", nombreitem = "Salir" });
            BindingContext = this;
        }

        

        private void lstMenu_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            MenuCLS omenuCLS = (MenuCLS)e.Item;
            switch (omenuCLS.nombreitem)
            {
                case "Averias":
                    App.Navigate.PushAsync(new Averias()); break;
                case "Instalaciones":
                    App.Navigate.PushAsync(new ListaInstalacion()); break;
                case "Clientes":
                    App.Navigate.PushAsync(new Cliente()); break;
                case "Salir":
                    App.Current.MainPage = new NavigationPage(new Login()); ; break;
            }
            App.MenuApp.IsPresented = false;
        }
    }
}