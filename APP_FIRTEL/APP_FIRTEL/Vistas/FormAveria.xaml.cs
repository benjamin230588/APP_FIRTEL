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
	public partial class FormAveria : ContentPage
	{
		public string  defecto { get; set; }
		public List<string> lista { get; set; }
		public FormAveria ()
		{

			InitializeComponent ();
			lista = new List<string>();
			lista.Add("Pendiente");
			lista.Add("Realizado");
			lista.Add("Ingresado");
			defecto = "Pendiente";
			combolista.BindingContext = lista;
			combolista.SetBinding(Picker.ItemsSourceProperty,".");
			combolista.BindingContext = defecto;
			//combolista.SetBinding(Picker.ItemsSourceProperty, ".");
			combolista.SetBinding(Picker.SelectedItemProperty, ".");
			//combolista.ItemDisplayBinding = new Binding("Name");
			//.ItemDisplayBinding = new Binding("Name");
			//picker.SetBinding(Picker.ItemsSourceProperty, "Monkeys");
			//defecto = "Pendiente";
			//BindingContext = this
			//BindingContext = defecto;


		}
	}
}