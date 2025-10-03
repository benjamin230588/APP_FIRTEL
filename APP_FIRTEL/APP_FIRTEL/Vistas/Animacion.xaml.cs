using APP_FIRTEL.Alertas;
using APP_FIRTEL.Conexion;
using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace APP_FIRTEL.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Animacion : ContentPage
    {
        public Animacion()
        {
            InitializeComponent();
          
        }

        private  void Button_Clicked(object sender, EventArgs e)
        {
            var notification = new NotificationRequest
            {
                NotificationId = DateTime.Now.Minute,
                Title = "Nuevo Pedido Atender",
                Description = "Esta es una notificación local usando NuGet",
                ReturningData = "Opcional: datos que regresan al tocar la notificación",
                Schedule =
                {
                    NotifyTime = DateTime.Now.AddSeconds(15)
                },

                Android = new Plugin.LocalNotification.AndroidOption.AndroidOptions
                {
                    ChannelId = "default",
                    IconSmallName = new Plugin.LocalNotification.AndroidOption.AndroidIcon("icnoti"),
                    Color = new Plugin.LocalNotification.AndroidOption.AndroidColor(unchecked((int)0xFF0000FF)),

                    // 🔹 El grande (a color, aparece al desplegar la notificación)
                    //   IconLargeName = new Plugin.LocalNotification.AndroidOption.AndroidIcon("icnotifondo"),
                   

                    AutoCancel = false,
                    Priority = NotificationPriority.High,
                   
                    Ongoing = true,

                }
                //NotifyTime = DateTime.Now.AddSeconds(1) // Se dispara en 1 segundo
            };
            //Device.BeginInvokeOnMainThread(async () =>
            //{
            //    await Application.Current.MainPage.DisplayAlert("Notificación",
            //        "Se mostró mientras la app está abierta", "OK");
            //});
            NotificationCenter.Current.Show(notification);

            //var resultado = await this.ShowPopupAsync(new alerta());

            //if (resultado is bool confirmado && confirmado)
            //{
            //    await DisplayAlert("Resultado", "Has confirmado con SÍ", "OK");
            //}
            //else
            //{
            //    await DisplayAlert("Resultado", "Has elegido NO", "OK");
            //}

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            string user = "admin";
            if (!string.IsNullOrEmpty(user))
            {
                // await Program.SignalRService.EnviarUsuarioAsync(user);
                //}
                Task.Run(async () =>
                {
                    await SignalRService.Instance.EnviarUsuarioAsync(user);
                });

            }

            
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page2());

           
        }
    }
}