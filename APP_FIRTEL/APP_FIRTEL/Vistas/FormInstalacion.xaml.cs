using APP_FIRTEL.Clases;
using APP_FIRTEL.Generic;
using APP_FIRTEL.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APP_FIRTEL.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormInstalacion : ContentPage
	{
		private MediaFile oMediaFile;
		public FormInstalacionModel vm { get; set; }
		public FormInstalacion(PostventaCLS objeto)
		{

			InitializeComponent();

			vm= new FormInstalacionModel(Navigation, objeto);

			BindingContext = vm;
			


		}

        private async void imgmaps_Clicked(object sender, EventArgs e)
        {
            //string cadena = "12.23rrr3";
            //double numero = 123.45;
             char delimitador = ',';
            string nombrecliente = txtnombre.Text + " " + txtnombresegundo.Text +  " " + txtapellido.Text;
            string coordenadas = txtcoordenadas.Text.Trim();
            string[] valores = coordenadas.Split(delimitador);
            if (!Double.TryParse(valores[0], out double lat))
            {
                await DisplayAlert("Error", "Coordenadas Incorrectas", "Cancelar");
                return;
            }
            if (!Double.TryParse(valores[1], out double longi))
            {
                await DisplayAlert("Error", "Coordenadas Incorrectas", "Cancelar");
                return;
            }


            var location = new Xamarin.Essentials.Location(lat,longi);
            var options = new MapLaunchOptions
            {
                Name = nombrecliente,
                NavigationMode = NavigationMode.None

            };
            //Launching Maps
            await Map.OpenAsync(location, options);
        }

        

        private async void imgcargaimagen_Clicked(object sender, EventArgs e)
        {
			await CrossMedia.Current.Initialize();
			oMediaFile = await CrossMedia.Current.PickPhotoAsync(
			new PickMediaOptions() { PhotoSize = PhotoSize.Custom,CustomPhotoSize=85 });

			//FileInfo fileinfo = new FileInfo(oMediaFile.Path);
			//var tamano = fileinfo.Length;
			//CrossMedia.Current.PickPhotoAsync(oMediaFile.Path);
			//oMediaFile.a
			//byte[] resizedImage = await Plugin.Media.CrossMedia.Current. .Current.re(originalImageBytes, 500, 1000);

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
				char delimitador = '/';
				
				string[] valores = oMediaFile.Path.Split(delimitador);
				string nombrefile1 =valores[valores.Length - 1];
				string[] nombrefile2 = nombrefile1.Split('.');
				string nombrefile = vm.objInstalacioncls.idpostventa + "_post."+ nombrefile2[1];
				vm.Imagenpost = GenericLH.convertirMediaFileAImageSource(oMediaFile);
				vm.Imgmedia = oMediaFile;
				vm.nombrefile = nombrefile;
				vm.objInstalacioncls.nombrearchivo = nombrefile;
			
				vm.alto = 300;
				vm.ancho = 330;
			}
		}

        private async void tabPreviewImage_Tapped(object sender, EventArgs e)
        {
			if(oMediaFile != null)
            {
				ImageSource imgenvio = GenericLH.convertirMediaFileAImageSource(oMediaFile);
				await Navigation.PushAsync(new Visualizadorimg("", imgenvio, 2));
			}
            else if (vm.objInstalacioncls.nombrearchivo != null)
            {
				await Navigation.PushAsync(new Visualizadorimg(vm.objInstalacioncls.rutaarchivo, null, 1));
				
            }

			
		}
    }
}