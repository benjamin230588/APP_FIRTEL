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
    public partial class Pagainaprincipal : MasterDetailPage
    {
        public Pagainaprincipal()
        {
            InitializeComponent();
            App.Navigate = Navigation;
            App.MenuApp = this;
            //App.Navigate.PushAsync(new Averias());
        }
    }
}