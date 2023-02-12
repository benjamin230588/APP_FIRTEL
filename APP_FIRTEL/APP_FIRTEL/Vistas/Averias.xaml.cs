using APP_FIRTEL.Clases;
using APP_FIRTEL.Generic;
using APP_FIRTEL.ViewModels;
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
    public partial class Averias : ContentPage
    {
        //public List<AveriaCLS> listaCategoria { get; set; }
        private int cantidad;
        public List<ListaEstado> listaestado { get; set; }
        public string fechadesde { get; set; }
        public string fechahasta { get; set; }
        //public  List<AveriaCLS> listatu = new List<AveriaCLS>();
        public static Averias instance;
        public AveriaModel vm;
        int estadoclave = 0;
        public  ObservableCollection<AveriaCLS> ListaAveria { get; set; } 


        public static Averias GetInstance()
        {
            if (instance == null)
            {
                return new Averias();

            }
            else return instance;
        }
        public Averias()
        {
            instance = this;
            InitializeComponent();
            ListaAveria = new ObservableCollection<AveriaCLS>();

            //listaCategoria.Add(new AveriaCLS { idaveria = 2, nombre = "josue" });
            //vm = new AveriaModel(Navigation);
            BindingContext = this;
            listaestado = new List<ListaEstado>(){
                new ListaEstado () { idestado=1 , nombre="Pendiente" ,bseleccionado=true},
                 new ListaEstado () { idestado=2 , nombre="Pendiente" ,bseleccionado=true},
                  new ListaEstado () { idestado=3 , nombre="Pendiente" ,bseleccionado=true},
                   new ListaEstado () { idestado=4 , nombre="Pendiente" ,bseleccionado=true}

            };
            DateTime dateactual = DateTime.Now;

            //Asi obtenemos el primer dia del mes actual
            DateTime oPrimerDiaDelMes = new DateTime(dateactual.Year, dateactual.Month, 1);

            //Y de la siguiente forma obtenemos el ultimo dia del mes
            //agregamos 1 mes al objeto anterior y restamos 1 día.
            DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddMonths(1).AddDays(-1);

            fechadesde = oPrimerDiaDelMes.ToString("dd/MM/yyyy");
            fechahasta = oUltimoDiaDelMes.ToString("dd/MM/yyyy");

            //consultaAverias();
            actualizarlista();


        }
        //private async void consultaAverias()
        //{

        //    string cadenaestado = "";
        //    foreach (ListaEstado objCat in vm.listaestado) cadenaestado = cadenaestado + "," + objCat.idestado;
        //    cadenaestado = cadenaestado.Substring(1, cadenaestado.Length - 1);


        //    actualizarlista();
        //    // vm.fechadesde, vm.fechahasta, cadenaestado
        //}
        //private async void actualizarlista()
        //{
        //    string cadenaestado = "";
        //    foreach (ListaEstado objCat in listaestado) cadenaestado = cadenaestado + "," + objCat.idestado;
        //    cadenaestado = cadenaestado.Substring(1, cadenaestado.Length - 1);

        //    vm.MostrarListaAverias(fechadesde,fechahasta,cadenaestado);
        //}
        //private void listaaveriafirtel_RemainingItemsThresholdReached(object sender, EventArgs e)
        //{
        //    MostrarListaAverias2();


        //}


        private async void actualizarlista()
        {
            Reply res;
            string cadenaestado = "";
            foreach (ListaEstado objCat in listaestado) cadenaestado = cadenaestado + "," + objCat.idestado;
            cadenaestado = cadenaestado.Substring(1, cadenaestado.Length - 1);
            var objeto = new Paginacion { pagine = 30, skip = 0, desde = fechadesde, hasta = fechahasta, idcliente = "", idestado = cadenaestado };

            ResultadoPaginacion<AveriaCLS> objres = new ResultadoPaginacion<AveriaCLS>();

            res = await GenericLH.GetAll<Paginacion>(Constantes.url + Constantes.api_getaveria, objeto);
            if (res.result == 1)
            {
                objres = JsonConvert.DeserializeObject<ResultadoPaginacion<AveriaCLS>>(JsonConvert.SerializeObject(res.data));

            }
            // objres.lista.ForEach((v) => v.fecha_registrostring = v.fecha_registro != null ? ((DateTime)v.fecha_registro).ToString("dd-MM-yyyy"):"");


            //ListaAveria = GenericLH.ToCollection<AveriaCLS>(objres.lista);
            //ListaAveria.Add(objres.lista[0]);
            //ListaAveria.Add(objres.lista[1]);
            //ListaAveria.Add(objres.lista[2]);
            //ListaAveria.Add(objres.lista[3]);
            cantidad = objres.cantidadregistro;
            for (int i = 0; i < objres.lista.Count; i++)
            {
                ListaAveria.Add(objres.lista[i]);
            }
        }

        public async void MostrarListaAverias2()
        {
            Reply res;
            string desde = "01/01/2023";
            string hasta = "02/01/2023";
            string estado = "1";
            //if (variable >= 3)
            //{
            //    return;
            //}
            var objeto = new Paginacion { pagine = 30, skip = 0, desde = desde, hasta = hasta, idcliente = "", idestado = estado };

            ResultadoPaginacion<AveriaCLS> objres = new ResultadoPaginacion<AveriaCLS>();

            res = await GenericLH.GetAll<Paginacion>(Constantes.url + Constantes.api_getaveria, objeto);
            if (res.result == 1)
            {
                objres = JsonConvert.DeserializeObject<ResultadoPaginacion<AveriaCLS>>(JsonConvert.SerializeObject(res.data));

            }
            // objres.lista.ForEach((v) => v.fecha_registrostring = v.fecha_registro != null ? ((DateTime)v.fecha_registro).ToString("dd-MM-yyyy"):"");

            //listatu.AddRange(objres.lista);
            for (int i = 0; i < objres.lista.Count; i++)
            {
                ListaAveria.Add(objres.lista[i]);
            }

            //ListaAveria.Add(objres.lista[0]);
            //ListaAveria.Add(objres.lista[1]);
            ////listaaveriafirtel.ItemsSource = listatu;
            //variable = variable + 1;

        }

        private void listaaveriafirtel_RemainingItemsThresholdReached(object sender, EventArgs e)
        {
            if (cantidad > ListaAveria.Count)
            {
                estadoclave = estadoclave + 1;
                MostrarListaAverias2();
            }
            
            
        }

        //private void listaaveriacol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    Navigation.PushAsync(new FormAveria());
        //}

        //private void btnfiltro_Clicked(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new FiltrosAveria());
        //}

        //private void lstCategoria_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    Navigation.PushAsync(new FormAveria());
        //}
    }
}