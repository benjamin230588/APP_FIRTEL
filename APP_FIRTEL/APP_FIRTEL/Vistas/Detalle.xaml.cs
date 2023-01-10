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
    public partial class Detalle : ContentPage
    {
        public List<heroes> listaheroes { get; set; }
        public Detalle()
        {
            InitializeComponent();
            listaheroes = new List<heroes>()
            { new heroes{ Name="NARUTO", AlterEgo="ricardo",Photo="https://akamai.sscdn.co/uploadfile/letras/fotos/2/5/7/4/2574f9070ce48b988fe2693a60c40427.jpg"},
              new heroes{ Name="Naruto", AlterEgo="ricao",Photo="https://somoskudasai.com/wp-content/uploads/2022/10/portada_naruto-19.jpg"},
              new heroes{ Name="OROCHIMARU", AlterEgo="ricdo",Photo="https://pm1.narvii.com/6239/abaf6bf870d0afc180390c0f9c0c61531c489c01_hq.jpg"}};

            BindingContext = this;
        }
    }
}