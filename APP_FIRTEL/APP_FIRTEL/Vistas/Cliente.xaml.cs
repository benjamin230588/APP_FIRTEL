using APP_FIRTEL.Clases;
using APP_FIRTEL.ViewModels;
using MiPrimeraAplicacionEnXamarinForm.Generic;
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
        public List<EClientes> listaclienteslst { get; set; }
		public ClienteModel oEntityCLS { get; set; }
		private int cantidad;
		private int skip;
		private int prueba=0;

		private List<EClientes> lista= new List<EClientes>();
		public Cliente()
        {
            InitializeComponent();
			oEntityCLS = new ClienteModel();
			//ObservableCollection
			oEntityCLS.listaCategoria = new List<EClientes>();
			//listaclienteslst = new List<EClientes>();
			//oEntityCLS.listaCategoria.Add(new EClientes { idcliente = 1, nombre = "benjamin Josue", apellido = "huaman soto ",direccion="las lomas de lima peru" ,codigocliente="bhdkkkdf",telefono="22334444",docdni="43e4444" });
		
			BindingContext = this;
			listarCategorias();
			//lstCategoria234.RefreshCommand = new Command(() =>
			//{

			//	listarCategorias();
			//});

			//listaclienteslst.RefreshCommand = new Command(() =>
			//{

			//	listarCategorias();
			//});
		}

		public async void listarCategorias()
		{
			//Aparezca el loading
			//var objeto = new { pagine = 0, skip = 10, nombre = "" };

			Reply res;
			Paginacion objeto = new Paginacion() { pagine = 30, skip = 0 };
			PaginacionCliente objres = new PaginacionCliente();
			//PaginacionCliente objres = new PaginacionCliente();
			//var restResponse = Restcall.MakeRequest(Constantes.url + Constantes.api_getcliente, Method.POST, null, objeto);
			//string obtenerURLGetCategoria = App.Current.Resources["GetCategoria"].ToString();
			//oEntityCLS.IsLoading = true;
			res = await GenericLH.GetAll<Paginacion>(Constantes.api_getcliente, objeto);
			if (res.result == 1)
			{
				objres = JsonConvert.DeserializeObject<PaginacionCliente>(JsonConvert.SerializeObject(res.data));

			}
			//List<CategoriaCLS> l =
			//	await GenericLH.GetAll<CategoriaCLS>(obtenerURLGetCategoria);
			/////En esta linea asigno nofoto-png a todas las filas

			oEntityCLS.listaCategoria = objres.lista;
			lista.AddRange(oEntityCLS.listaCategoria);
			cantidad = objres.registro;

			//oEntityCLS.listaCategoria = l;
			//lista = oEntityCLS.listaCategoria;



		}

        private void searchcliente_SearchButtonPressed(object sender, EventArgs e)
        {
            SearchBar obj = sender as SearchBar;
            string texto = obj.Text;
            if (texto == "") oEntityCLS.listaCategoria = lista;
            else oEntityCLS.listaCategoria = lista.Where(p => p.nombre.ToUpper().Contains(texto.ToUpper())).ToList();
            //DisplayAlert("Error", texto, "Cancelar");
        }

        private  void lstCategoria12_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var item = (EClientes)e.Item;
			var ultimo = lista.Last();

			if (item.nombre == ultimo.nombre)
            {
				prueba++;
				//DisplayAlert("Error", item.nombre, "Cancelar");
			   listarCategoriasotro(prueba);

			}
            ////}
        }

		public async void listarCategoriasotro(int prueba)
		{
			//Aparezca el loading
			//var objeto = new { pagine = 0, skip = 10, nombre = "" };

			Reply res;
			//int paginacion = cantidad % 30;
			//int final;
			//if (paginacion == 0)
   //         {
			//	final = paginacion;
   //         }
			//else
   //         {
			//	final = paginacion + 1;
   //         }
			Paginacion objeto = new Paginacion() { pagine = 30, skip = prueba*30};
			PaginacionCliente objres = new PaginacionCliente();
			//PaginacionCliente objres = new PaginacionCliente();
			//var restResponse = Restcall.MakeRequest(Constantes.url + Constantes.api_getcliente, Method.POST, null, objeto);
			//string obtenerURLGetCategoria = App.Current.Resources["GetCategoria"].ToString();
			//oEntityCLS.IsLoading = true;
			res = await GenericLH.GetAll<Paginacion>(Constantes.api_getcliente, objeto);
			if (res.result == 1)
			{
				objres = JsonConvert.DeserializeObject<PaginacionCliente>(JsonConvert.SerializeObject(res.data));

			}
			//List<CategoriaCLS> l =
			//	await GenericLH.GetAll<CategoriaCLS>(obtenerURLGetCategoria);
			/////En esta linea asigno nofoto-png a todas las filas

			//oEntityCLS.listaCategoria = objres.lista;
			////AddRange(objres.lista);
			////oEntityCLS.listaCategoria = l;
			//lista = oEntityCLS.listaCategoria;

			//List<EClientes> benja = new List<EClientes>();
		 //   lista.AddRange(objres.lista);
			//benja = lista;
			lista.AddRange(objres.lista);
			oEntityCLS.listaCategoria.AddRange(objres.lista);
			//Add(new EClientes { idcliente = 1, nombre = "benjamin Josue", apellido = "huaman soto ",direccion="las lomas de lima peru" ,codigocliente="bhdkkkdf",telefono="22334444",docdni="43e4444" });
			////lstCategoria12.ItemsSource = null;
			////lstCategoria12.ItemsSource = oEntityCLS.listaCategoria;


		}

	}
}