using APP_FIRTEL.Genericos;
using APP_FIRTEL.Recursos;
using APP_FIRTEL.Vistas;
using System;
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
            LoadStyles();
            // Application.Current.MainPage = new Page2();
            if (Setings.RecordarContra == true)
            {
                Application.Current.MainPage = new Pagainaprincipal();
            }
            else
            {
                MainPage = new NavigationPage(new Login());
            }

        }
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

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
