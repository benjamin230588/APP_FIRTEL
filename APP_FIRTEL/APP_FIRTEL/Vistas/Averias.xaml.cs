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
using Utilitarios_App;
using Utilitarios_App.viewmodel;
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
        public static bool actualiza = false;
        public string fechahasta { get; set; }
        //public  List<AveriaCLS> listatu = new List<AveriaCLS>();
        public static Averias instance;
        public AveriaModel vm { get; set; }
        private int skipcantidad = 0;
        // int estadoclave = 0;
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
            vm = new AveriaModel(Navigation);
            BindingContext = vm;
            listaaveriafirtel.BindingContext = ListaAveria;
            listaaveriafirtel.SetBinding(CollectionView.ItemsSourceProperty, ".");
            
            //gridcontenido.bi
            
            listaestado = new List<ListaEstado>(){
                new ListaEstado () { idestado=1 , nombre="Pendiente" ,bseleccionado=true}
            };
            vm.flgindicador = true;
            DateTime dateactual = DateTime.Now;

            //Asi obtenemos el primer dia del mes actual
            DateTime oPrimerDiaDelMes = new DateTime(dateactual.Year, dateactual.Month, 1);

            //Y de la siguiente forma obtenemos el ultimo dia del mes
            //agregamos 1 mes al objeto anterior y restamos 1 día.
            DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddMonths(1).AddDays(-1);

            fechadesde = "01/01/2023";
            fechahasta = oUltimoDiaDelMes.ToString("dd/MM/yyyy");
            skipcantidad = 0;
            this.Appearing += Averias_Appearing;
            lstrefrescador.Command = new Command(() =>
            {

                //listarDatos();
                actualizarlista(fechadesde, fechahasta, listaestado);
                lstrefrescador.IsRefreshing = false;
            });
            //consultaAverias();
            actualizarlista(fechadesde,fechahasta,listaestado);


        }
       

        public async void actualizarlista(string desde1,string hasta1, List<ListaEstado> listaestadoave)
        {
            Reply res;
            string cadenaestado = "";
            skipcantidad = 0;
            foreach (ListaEstado objCat in listaestadoave) cadenaestado = cadenaestado + "," + objCat.idestado;
            cadenaestado = cadenaestado.Substring(1, cadenaestado.Length - 1);
            var objeto = new Paginacion { pagine = 10, skip = skipcantidad*10, desde = desde1, hasta = hasta1, idcliente = "", idestado = cadenaestado };

            ResultadoPaginacion<AveriaCLS> objres = new ResultadoPaginacion<AveriaCLS>();

            res = await GenericLH.GetAll<Paginacion>(Constantes.url + Constantes.api_getaveria, objeto);
            if (res.result == 1)
            {
                objres = JsonConvert.DeserializeObject<ResultadoPaginacion<AveriaCLS>>(JsonConvert.SerializeObject(res.data));

            }
          
            cantidad = objres.cantidadregistro;
            ListaAveria.Clear();
            for (int i = 0; i < objres.lista.Count; i++)
            {
                ListaAveria.Add(objres.lista[i]);
            }
            vm.flgindicador = false;
        }

        public async void MostrarListaAverias2(int skipcantidad)
        {
            Reply res;
           
            string cadenaestado = "";
            foreach (ListaEstado objCat in listaestado) cadenaestado = cadenaestado + "," + objCat.idestado;
            cadenaestado = cadenaestado.Substring(1, cadenaestado.Length - 1);
            var objeto = new Paginacion { pagine = 10, skip = skipcantidad*10, desde = fechadesde, hasta = fechahasta, idcliente = "", idestado = cadenaestado };

            ResultadoPaginacion<AveriaCLS> objres = new ResultadoPaginacion<AveriaCLS>();

            res = await GenericLH.GetAll<Paginacion>(Constantes.url + Constantes.api_getaveria, objeto);
            if (res.result == 1)
            {
                objres = JsonConvert.DeserializeObject<ResultadoPaginacion<AveriaCLS>>(JsonConvert.SerializeObject(res.data));

            }
            // objres.lista.ForEach((v) => v.fecha_registrostring = v.fecha_registro != null ? ((DateTime)v.fecha_registro).ToString("dd-MM-yyyy"):"");
            cantidad = objres.cantidadregistro;
            //listatu.AddRange(objres.lista);
            for (int i = 0; i < objres.lista.Count; i++)
            {
                ListaAveria.Add(objres.lista[i]);
            }

            

        }

        private void listaaveriafirtel_RemainingItemsThresholdReached(object sender, EventArgs e)
        
        {
            if (cantidad > ListaAveria.Count)
            {
                skipcantidad++;
                MostrarListaAverias2(skipcantidad);
            }
            
            
        }
        private  void Averias_Appearing(object sender, EventArgs e)
        {
            if(actualiza==true)
            {
                actualizarlista(fechadesde, fechahasta, listaestado);
                actualiza = false;
            }
            
        }


    }
}