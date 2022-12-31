using APP_FIRTEL.Vistas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APP_FIRTEL
{
    public partial class App : Application
    {
        public static NavigationPage Navigate { get; internal set; }
        public static Pagainaprincipal MenuApp { get; internal set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Paginainicio());
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
