using APP_FIRTEL.Clases;
using APP_FIRTEL.Generic;
using APP_FIRTEL.ViewModels;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APP_FIRTEL.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormCliente : ContentPage
    {
        public ClienteCLS objcliente { get; set; } = new ClienteCLS();
		private MediaFile oMediaFile;
		public ClienteModel oCategoriaModel { get; set; } = new ClienteModel();

		public string titulo { get; set; }

        public FormCliente(ClienteCLS obj, string nombretitulo)
        {
           
            InitializeComponent();       
            objcliente = obj;       
            titulo = nombretitulo;
			oCategoriaModel.Imagen = obj.nombrearchivo == null ? null : obj.rutaarchivo;
			if(obj.nombrearchivo == null)
            {
				objcliente.alto = 50;
				objcliente.ancho = 100;

			}
			else
            {
				
				objcliente.alto = 300;
				objcliente.ancho = 330;

			}
			
			BindingContext = this;
            //dtfecha.NullableDate = null;


        }

        private async void btnvolvercliente_Clicked(object sender, EventArgs e)
        {
			// var prueba =cmboestado23.SelectedItem;
			await Navigation.PopAsync();
		   
			

		}

   //     private async void tabPreviewImage_Tapped(object sender, EventArgs e)
   //     {
			//await CrossMedia.Current.Initialize();
			//oMediaFile = await CrossMedia.Current.PickPhotoAsync();


			
			////DisplayActionSheet()
			//string opcion = await DisplayActionSheet("Seleccione una Opciòn", "Cancelar", null, "Galeria", "Camara");
			//switch (opcion)
			//{
			//	//En caso que elijes una foto de tu galeria
			//	case "Galeria":
				
			//		; break;
			//	//En el caso que te tomas una foto y lo subes
			//	case "Camara":
			//		await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
			//		{
			//			Directory = "Pictures",
			//			Name = "Prueba.jpg",
			//			PhotoSize = PhotoSize.Small
			//		});
			//		; break;
			//	//Que no seleccionas ninguna opcion
			//	default:
			//		oMediaFile = null;
			//		break;

			//}
		//	if (oMediaFile != null)
		//	{
		//		oCategoriaModel.Imagen = GenericLH.convertirMediaFileAImageSource(oMediaFile);
		//	}

		//}
	}
}