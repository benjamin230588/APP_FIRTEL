using APP_FIRTEL.Clases;
using APP_FIRTEL.ViewModels;
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
	public partial class FormInstalacion : ContentPage
	{
	
		public FormInstalacion(PostventaCLS objeto)
		{

			InitializeComponent();


			
			BindingContext = new FormInstalacionModel(Navigation, objeto);
			


		}
	}
}