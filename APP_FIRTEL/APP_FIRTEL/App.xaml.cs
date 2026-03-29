using APP_FIRTEL.Clases;
using APP_FIRTEL.Conexion;
using APP_FIRTEL.Genericos;
using APP_FIRTEL.Interfaces;
using APP_FIRTEL.Recursos;
using APP_FIRTEL.Vistas;
using Plugin.LocalNotification;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APP_FIRTEL
{
    public partial class App : Application
    {
        public static NavigationPage Navigate { get; internal set; }
        public static Pagainaprincipal MenuApp { get; internal set; }
        const int smallWightResolution = 700;
        const int smallHeightResolution = 1500;
        const int medioWightResolution = 730;
        const int medioHeightResolution = 1550;

        public App()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<object, string>(this, "NotificationTapped", async (sender, payload) =>
            {
                await OnLocalNotificationTapped(payload);
            });
            LoadStyles();
            var deviceId = DependencyService.Get<IDeviceService>().GetDeviceId();
            VerificarVersionYLimpiarPreferencias();
            //Application.Current.MainPage = new Pruebasxaml();
            //fffff
            //delissss   ssss
            //   change
            if (Preferences.Get(Preferencias.RecordarContra, false) == true)
            {
                Application.Current.MainPage = new Pagainaprincipal();
            }
            else
            {
                MainPage = new NavigationPage(new Login());
            }
           // MainPage = new NavigationPage(new Animacion());
            //NotificationCenter.Current.NotificationTapped += OnNotificationTapped;
            //Plugin.LocalNotification.NotificationCenter.Current.NotificationTapped += OnNotificationTapped;
            //LocalNotificationCenter.Current.NotificationTapped += OnLocalNotificationTapped;
            // Suscribirse al evento de toque en la notificación
            //LocalNotificationCenter.Current.NotificationTapped += OnLocalNotificationTapped;

            //NotificationCenter.Current.NotificationTapped += OnLocalNotificationTapped;
            // NotificationCenter.Current.NotificationTapped += OnLocalNotificationTapped;

            // Revisar si la app fue abierta desde una notificación
            //var lastRequest = NotificationCenter.Current.GetLastNotificationResponse();
            //if (lastRequest != null)
            //{
            //    HandleNotification(lastRequest);
            //}
            //Task.Run(async () =>
            //{
            //    await SignalRService.Instance.StartConnectionAsync();
            //});

        }

        private void VerificarVersionYLimpiarPreferencias()
        {
            
            string versionGuardada =  Preferences.Get(Preferencias.idversion, "");

            string versionActual = VersionTracking.CurrentVersion; // Versión actual de la app

            if (versionGuardada != versionActual)
            {
                
                //Preferences.Clear(); // ← Borra TODO
                //Setings.RecordarContra = false;
                Preferences.Set(Preferencias.RecordarContra, false);
                Preferences.Set(Preferencias.IdUsuario, 0);
                Preferences.Set(Preferencias.nomusuario, "");
                Preferences.Set(Preferencias.IdTipoUsuario, 0);
                


                // Guardamos la nueva versión para futuras comparaciones
                Preferences.Set(Preferencias.idversion, versionActual);
            }
        }
        //private async  void OnLocalNotificationTapped(NotificationEventArgs e)
        //{
        //    // Aquí obtienes los datos que enviaste
        //    //string data = e.Request.ReturningData;

        //    // Mostrar alerta o navegar a otra página
        //    //MainPage = new Paginaopciones();
        //    await MainPage.Navigation.PushAsync(new Paginaopciones());
        //  //  await MainPage.DisplayAlert("Notificación", $"Tocaste la notificación: ", "OK");
        //}
     
        void LoadStyles()
        {
            if (IsASmallDevice())
            {
                dictionary.MergedDictionaries.Add(DesignSmall.SharedInstance);
            }
            else
            {
                if (Ismedioevice())
                {
                    dictionary.MergedDictionaries.Add(Disenonormal.SharedInstance);
                }
                else
                {
                    dictionary.MergedDictionaries.Add(DisegnLarge.SharedInstance);

                }
            }
        }

        public static bool IsASmallDevice()
        {
            // Get Metrics

            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            var mainDisplayInfo23 = DeviceDisplay.MainDisplayInfo.Density;

            // Width (in pixels)
            var width = mainDisplayInfo.Width;

            // Height (in pixels)
            var height = mainDisplayInfo.Height;
            return (width <= smallWightResolution && height <= smallHeightResolution);
        }
        public static bool Ismedioevice()
        {
            // Get Metrics

            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            // Width (in pixels)
            var width = mainDisplayInfo.Width;

            // Height (in pixels)
            var height = mainDisplayInfo.Height;
            return (width <= medioWightResolution && height <= medioHeightResolution);
        }
        protected override void OnStart()
        {
            
        }
        private async Task OnLocalNotificationTapped(string payload)
        {

            bool estaLogueado = Preferences.Get(Preferencias.RecordarContra, false);

            if (!estaLogueado)
            {
                // Redirigir al Login
                 App.Current.MainPage = new NavigationPage(new Login());
                return;
            }
            // Ejemplo: payload = "PaginaOpciones"
            if (payload == "AVERIAS")
            {
                await App.Navigate.PushAsync(new Averias());
              //  await MainPage.Navigation.PushAsync(new Paginaopciones());
            }
            else if (payload=="RECOJOS")
            {
                await App.Navigate.PushAsync(new Recojos());
            }
            else if (payload == "POSTVENTA")
            {
                await App.Navigate.PushAsync(new Instalacion());
            }

            
        }
        protected override void OnSleep()
        {
        }

        
        protected override void OnResume()
        {
            //base.OnResume();

            //if (SignalRService.Instance.validarconexion()==1)
            //{
            //    string cadena = "si";
            //}
        }
    }
}
