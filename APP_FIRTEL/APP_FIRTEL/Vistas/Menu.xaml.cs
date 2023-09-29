using APP_FIRTEL.Clases;
using APP_FIRTEL.Genericos;
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
        public string mensajeusuario { get; set; }
        public Menu()
        {
            InitializeComponent();
            string nomusuario = Setings.nomusuario;
            listamenu = new List<MenuCLS>();
            mensajeusuario = nomusuario;
            BindingContext = this;
            listarMenu();
        }

        private void listarMenu()
        {
            int idtipousuario = Setings.IdTipoUsuario;
            if( idtipousuario==1)
            {
                listamenu.Add(new MenuCLS { nombreicono = "ic_cliente", nombreitem = "Clientes" });
                listamenu.Add(new MenuCLS { nombreicono = "ic_averia", nombreitem = "Averias" });
                listamenu.Add(new MenuCLS { nombreicono = "ic_recojo", nombreitem = "Recojos" });
                listamenu.Add(new MenuCLS { nombreicono = "ic_producto", nombreitem = "Instalaciones" });
                listamenu.Add(new MenuCLS { nombreicono = "ic_cerrar", nombreitem = "Salir" });

            }
            else
            {
              
                listamenu.Add(new MenuCLS { nombreicono = "ic_averia", nombreitem = "Averias" });
                listamenu.Add(new MenuCLS { nombreicono = "ic_recojo", nombreitem = "Recojos" });
                listamenu.Add(new MenuCLS { nombreicono = "ic_producto", nombreitem = "Instalaciones" });
                listamenu.Add(new MenuCLS { nombreicono = "ic_cerrar", nombreitem = "Salir" });
            }
            
        }

        private void lstMenu_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            MenuCLS omenuCLS = (MenuCLS)e.Item;
            switch (omenuCLS.nombreitem)
            {
                case "Averias":
                    App.Navigate.PushAsync(new Averias()); break;
                case "Recojos":
                    App.Navigate.PushAsync(new Recojos()); break;
                case "Instalaciones":
                    App.Navigate.PushAsync(new Instalacion()); break;
                case "Clientes":
                    App.Navigate.PushAsync(new Cliente()); break;
                case "Salir":
                    App.Current.MainPage = new NavigationPage(new Login()); 
                    Setings.RecordarContra = false;
                    break;
            }
            App.MenuApp.IsPresented = false;
        }
    }
}