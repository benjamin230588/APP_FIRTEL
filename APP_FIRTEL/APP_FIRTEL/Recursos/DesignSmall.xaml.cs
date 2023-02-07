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
    public partial class DesignSmall : ResourceDictionary
    {
        public static DesignSmall SharedInstance { get; } = new DesignSmall();
        public DesignSmall()
        {
            InitializeComponent();
        }
    }
}