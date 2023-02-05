using APP_FIRTEL.Clases;
using APP_FIRTEL.ViewModels;
using APP_FIRTEL.Generic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios_Firtel;
using Utilitarios_Firtel.viewmodel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APP_FIRTEL.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cliente : ContentPage
    {
		// listar grabar y detalle
        //public List<ECliente> listaclienteslst { get; set; }
		//public ClienteModel oEntityCLS { get; set; }
		private int cantidad;
		private int skip;
		private int skipcantidad = 0;
		private int buscador = 1;
		public string nombreproducto { get; set; }


		private List<ClienteCLS> lista= new List<ClienteCLS>();
		public Cliente()
        {
            InitializeComponent();
			//BindingContext = this;
			listarCategoriasinicio(0);
		
		}

		public async void listarCategorias(int skipcantidad)
		{
			//Aparezca el loading
			//var objeto = new { pagine = 0, skip = 10, nombre = "" };

			Reply res;
			Paginacion objeto = new Paginacion() { pagine = 30, skip = skipcantidad * 30 };
			ResultadoPaginacion<ClienteCLS> objres = new ResultadoPaginacion<ClienteCLS>();
			
			res = await GenericLH.GetAll<Paginacion>(Constantes.url + Constantes.api_getcliente, objeto);
			if (res.result == 1)
			{
				objres = JsonConvert.DeserializeObject<ResultadoPaginacion<ClienteCLS>>(JsonConvert.SerializeObject(res.data));

			}
		
			lista.AddRange(objres.lista);
			cantidad = objres.cantidadregistro;
			lstCategoria12.ItemsSource = null;
			lstCategoria12.ItemsSource = lista;
			



		}
		public async void listarCategoriasinicio(int skipcantidad)
		{
			//Aparezca el loading
			//var objeto = new { pagine = 0, skip = 10, nombre = "" };

			Reply res;
			Paginacion objeto = new Paginacion() { pagine = 30, skip = skipcantidad * 30 };
			ResultadoPaginacion<ClienteCLS> objres = new ResultadoPaginacion<ClienteCLS>();

			res = await GenericLH.GetAll<Paginacion>(Constantes.url + Constantes.api_getcliente, objeto);
			if (res.result == 1)
			{
				objres = JsonConvert.DeserializeObject<ResultadoPaginacion<ClienteCLS>>(JsonConvert.SerializeObject(res.data));

			}

			lista=objres.lista;
			cantidad = objres.cantidadregistro;
			lstCategoria12.ItemsSource = null;
			lstCategoria12.ItemsSource = lista;




		}
		private async void searchcliente_SearchButtonPressed(object sender, EventArgs e)
        {
			

			SearchBar obj = sender as SearchBar;
			string texto = obj.Text;
			Reply res;
			skipcantidad = 0;
			
			Paginacion objeto = new Paginacion() { pagine = 30, skip = 0, nombre = texto };
			ResultadoPaginacion<ClienteCLS> objres = new ResultadoPaginacion<ClienteCLS>();
			res = await GenericLH.GetAll<Paginacion>(Constantes.url + Constantes.api_getcliente, objeto);
			if (res.result == 1)
			{
				objres = JsonConvert.DeserializeObject<ResultadoPaginacion<ClienteCLS>>(JsonConvert.SerializeObject(res.data));

			}


			lista = objres.lista;
			cantidad = objres.cantidadregistro;
			lstCategoria12.ItemsSource = null;
			lstCategoria12.ItemsSource = lista;
			
		}

		private  void lstCategoria12_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var item = (ClienteCLS)e.Item;
			var ultimo = lista.Last();

            if ( cantidad > lista.Count )
            {
				if (item.nombre == ultimo.nombre)
				{
					skipcantidad++;
					//DisplayAlert("Error", item.nombre, "Cancelar");
					listarCategorias(skipcantidad);

				}
			}
			
           
        }

        private void searchcliente_TextChanged(object sender, TextChangedEventArgs e)
        {
			string valor = e.NewTextValue;
			if (valor == "")
			{
				skipcantidad = 0;
				listarCategoriasinicio(skipcantidad);
			}
		}

        private void lstCategoria12_ItemTapped(object sender, ItemTappedEventArgs e)
        {
			ClienteCLS objCliente = (ClienteCLS)e.Item;
			Navigation.PushAsync(new FormCliente(objCliente, "Detalle Cliente"));
		}
    }
}