using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APP_FIRTEL.Alertas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class alerta : Popup
    {
        public alerta()
        {
            InitializeComponent();
        }
        private void Cerrar_Clicked(object sender, System.EventArgs e)
        {
            Dismiss(true);
        }
    }
}