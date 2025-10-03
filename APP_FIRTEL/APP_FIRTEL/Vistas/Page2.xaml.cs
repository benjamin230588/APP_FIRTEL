using APP_FIRTEL.Conexion;
using Plugin.LocalNotification;
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
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
            SignalRService.Instance.OnMensajeRecibido += (msg) =>
            {
                // Como esto viene de un hilo de SignalR,
                // lo pasamos al hilo UI
                Device.BeginInvokeOnMainThread(() =>
                {
                    var notification = new NotificationRequest
                    {
                        NotificationId = DateTime.Now.Minute,
                        Title = "Nuevo Pedido Atender",
                        Description = "Nueva INSTALACION AHORA DIA AÑO",
                        ReturningData = "Opcional: datos que regresan al tocar la notificación",
                        Schedule =
                {
                    NotifyTime = DateTime.Now.AddSeconds(2)
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


                    // Suponiendo que tienes un ObservableCollection<Alumno> llamado lista
                    //DisplayAlert("aviso",msg,"cc");

                    // Si estás usando Binding a un ListView o CollectionView,
                    // ObservableCollection actualiza automáticamente la UI
                });
            };
        }
    }
}