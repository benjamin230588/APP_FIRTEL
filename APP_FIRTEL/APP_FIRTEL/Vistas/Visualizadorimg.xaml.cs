using APP_FIRTEL.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APP_FIRTEL.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Visualizadorimg : ContentPage
    {
       // public string rutaimg { get; set; }
        public ImageSource rutaimg { get; set; }
        public Visualizadorimg(string ruta,ImageSource img ,int tipo)
        {
            InitializeComponent();
            //var imageg = new ByteImage { Source = ruta };

            //byte[] img = Convert.FromBase64String(ruta);
            //MemoryStream ms = new MemoryStream(img);
            // rutaimg = ImageSource.FromFile(ruta);
            // imgvista
            // rutaimg = ruta;
            traebytes(ruta,img,tipo);
            BindingContext = this;
        }

        public async void traebytes(string url, ImageSource img,int tipo)
        {
            byte[] bytes;
            if (tipo==1)
            {
                using (HttpClient client = new HttpClient())
                {
                    byte[] fileArray = await client.GetByteArrayAsync(url);
                    bytes = fileArray;
                }
                rutaimg = ImageSource.FromStream(() => new MemoryStream(bytes));
                imgvista.Source = rutaimg;
            }
            else
            {
                imgvista.Source = img;
            }
            
           
            //////ImageConverter Class convert Image object to Byte array.
            //byte[] bytes = imageg.by

           

        }
    }
}