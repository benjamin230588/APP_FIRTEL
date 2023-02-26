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
			oCategoriaModel.Imagen = obj.cadenaflujo == null ? null : GenericLH.convertirArrayDeBytesAImageSource(obj.cadenaflujo);
			if(obj.cadenaflujo == null)
            {
				objcliente.alto = 50;
				objcliente.ancho = 100;

			}
			else
            {
				
				objcliente.alto = 300;
				objcliente.ancho = 500;

			}
			
			BindingContext = this;
            //dtfecha.NullableDate = null;


        }

        private async void btnvolvercliente_Clicked(object sender, EventArgs e)
        {
			// var prueba =cmboestado23.SelectedItem;
			//await Navigation.PopAsync();
		   string url23 = "http://192.168.1.34:45455/Clientes/Grabar";
			byte[] buffer = new byte[0];
			Stream s = oMediaFile.GetStream();
			using (MemoryStream ms = new MemoryStream())
			{
				s.CopyTo(ms);
			   buffer = ms.ToArray();
				
			}
			Stream datos2 = new MemoryStream(buffer);
			HttpClient cliente = new HttpClient();
			using (var multipartFormContent = new MultipartFormDataContent())
			{
				//Load the file and set the file's Content-Type header
				var fileStreamContent = new StreamContent(datos2);
				fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");

				//Add the file
				multipartFormContent.Add(fileStreamContent, name: "file", fileName: "ho11use.jpg");

				//Send it
				//var jsonPayload = "that payload from the above sample";
				var jsonPayload = JsonConvert.SerializeObject(new ClienteCLS() { idcliente = 29 });
				var jsonBytes = Encoding.UTF8.GetBytes(jsonPayload);
				var jsonContent = new StreamContent(new MemoryStream(jsonBytes));
				jsonContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

				multipartFormContent.Add(jsonContent, "modelo", "metadata.json");

				var response = await cliente.PostAsync(url23, multipartFormContent);
				response.EnsureSuccessStatusCode();
				
			}

		}

        private async void tabPreviewImage_Tapped(object sender, EventArgs e)
        {
			await CrossMedia.Current.Initialize();
			oMediaFile = await CrossMedia.Current.PickPhotoAsync();


			
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
			if (oMediaFile != null)
			{
				oCategoriaModel.Imagen = GenericLH.convertirMediaFileAImageSource(oMediaFile);
			}

		}
	}
}