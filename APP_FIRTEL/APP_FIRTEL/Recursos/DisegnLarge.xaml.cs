using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APP_FIRTEL.Recursos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisegnLarge : ResourceDictionary
    {
        public static DisegnLarge SharedInstance { get; } = new DisegnLarge();
        public DisegnLarge()
        {
            InitializeComponent();
        }
    }
}