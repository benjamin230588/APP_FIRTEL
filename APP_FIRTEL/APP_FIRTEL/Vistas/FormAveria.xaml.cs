using APP_FIRTEL.Clases;
using APP_FIRTEL.Generic;
using APP_FIRTEL.ViewModels;
using Plugin.LocalNotification;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APP_FIRTEL.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormAveria : ContentPage
	{
        //public string  defecto { get; set; }
        //public List<string> lista { get; set; }
        private MediaFile oMediaFile;
        public FormAveriaModel vm { get; set; }
        public FormAveria (AveriaCLS objeto)
		{

			InitializeComponent ();

			
			//lista = new List<string>();
			//lista.Add("Pendiente");
			//lista.Add("Realizado");
			//lista.Add("Ingresado");
			//defecto = "Pendiente";
			//combolista.BindingContext = lista;
			vm = new FormAveriaModel(Navigation, objeto);
            BindingContext = vm;

            //         combolista.SetBinding(Picker.ItemsSourceProperty, ".");
            //         combolista.BindingContext = defecto;
            //         //combolista.SetBinding(Picker.ItemsSourceProperty, ".");
            //         combolista.SetBinding(Picker.SelectedItemProperty, ".");
            //         combolista.ItemDisplayBinding = new Binding("Name");
            //.ItemDisplayBinding = new Binding("Name");
            //         picker.SetBinding(Picker.ItemsSourceProperty, "Monkeys");
            //         defecto = "Pendiente";
            //         BindingContext = this

            //         BindingContext = defecto;


        }

        private async void imgmaps_Clicked(object sender, EventArgs e)
        {
            try
            {
                char delimitador = ',';
                string nombrecliente = txtnombre.Text;
                    //+ " " + txtnombresegundo.Text + " " + txtapellido.Text;
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


                var location = new Xamarin.Essentials.Location(lat, longi);
                var options = new MapLaunchOptions
                {
                    Name = nombrecliente,
                    NavigationMode = NavigationMode.None

                };
                //Launching Maps
                await Map.OpenAsync(location, options);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Coordenadas Incorrectas", "Cancelar");

            }
        }

        private async void imgcargaimagen_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            //oMediaFile = await CrossMedia.Current.PickPhotoAsync();
            oMediaFile = await CrossMedia.Current.PickPhotoAsync(
            new PickMediaOptions() { PhotoSize = PhotoSize.Custom, CustomPhotoSize = 60 });

            //string ruta = oMediaFile.Path;
            //FileInfo fileinfo = new FileInfo(oMediaFile.Path);
            //var tamano = fileinfo.Length;
            //byte[] objetoarray= new byte[0]; 

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
                string nombrefile1 = valores[valores.Length - 1];
                string[] nombrefile2 = nombrefile1.Split('.');
                string nombrefile = vm.objaveriacls.idcorrelativo + "_averia." + nombrefile2[1];
                vm.Imagenpost = GenericLH.convertirMediaFileAImageSource(oMediaFile);
                //pasar al btes de frente
                vm.Imgmedia = oMediaFile;
                vm.nombrefile = nombrefile;
                vm.objaveriacls.nombrearchivo = nombrefile;

                vm.alto = 300;
                vm.ancho = 330;
            }

        }

        private async void tabPreviewImage_Tapped(object sender, EventArgs e)
        {
            if (oMediaFile != null)
            {
                ImageSource imgenvio = GenericLH.convertirMediaFileAImageSource(oMediaFile);
                await Navigation.PushAsync(new Visualizadorimg("", imgenvio, 2));
            }
            else if (vm.objaveriacls.nombrearchivo != null)
            {
                await Navigation.PushAsync(new Visualizadorimg(vm.objaveriacls.rutaarchivo, null, 1));

            }
        }

        private async void imgmapsnueva_Clicked(object sender, EventArgs e)
        {
            try
            {
                char delimitador = ',';
                string nombrecliente = txtnombre.Text;
                //+ " " + txtnombresegundo.Text + " " + txtapellido.Text;
                string coordenadas = txtcoordenadasnueva.Text.Trim();
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


                var location = new Xamarin.Essentials.Location(lat, longi);
                var options = new MapLaunchOptions
                {
                    Name = nombrecliente,
                    NavigationMode = NavigationMode.None

                };
                //Launching Maps
                await Map.OpenAsync(location, options);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Coordenadas Incorrectas", "Cancelar");

            }
        }

        private void btnVolverLn_Clicked(object sender, EventArgs e)
        {
            var notification = new NotificationRequest
            {
                NotificationId = 100,
                Title = "Hola!",
                Description = "Esta es una notificación local usando NuGet",
                ReturningData = "Opcional: datos que regresan al tocar la notificación",

                Android = new Plugin.LocalNotification.AndroidOption.AndroidOptions
                {
                    ChannelId = "default",

                    AutoCancel = true,

                }
                //NotifyTime = DateTime.Now.AddSeconds(1) // Se dispara en 1 segundo
            };
            //Device.BeginInvokeOnMainThread(async () =>
            //{
            //    await Application.Current.MainPage.DisplayAlert("Notificación",
            //        "Se mostró mientras la app está abierta", "OK");
            //});
            NotificationCenter.Current.Show(notification);
        }


        //private void btnRegistrarUsuario_Clicked(object sender, EventArgs e)
        //{

        //}
    }
}