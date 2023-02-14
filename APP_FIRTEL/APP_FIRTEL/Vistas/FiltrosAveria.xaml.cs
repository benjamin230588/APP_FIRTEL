using APP_FIRTEL.Clases;
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
    public partial class FiltrosAveria : ContentPage
    {
        public List<ListaEstado> oEntityCLS { get; set; }
        public DateTime Fdesde { get; set; }
        public DateTime Fhasta { get; set; }
        public FiltrosAveria()
        {
            InitializeComponent();
            oEntityCLS = new List<ListaEstado>(){
                new ListaEstado () { idestado=1 , nombre="Pendiente" ,bseleccionado=false},
                new ListaEstado () { idestado=2 , nombre="Proceso" , bseleccionado=false},
                new ListaEstado () { idestado=3 , nombre="Realizado"  ,bseleccionado=false},
                new ListaEstado () { idestado=4 , nombre="Terminado" , bseleccionado=false},
            };

            Averias obj = Averias.GetInstance();
            foreach (ListaEstado objCat in oEntityCLS)
            {
                foreach (ListaEstado obj2 in obj.listaestado)
                {
                    if (objCat.idestado == obj2.idestado)
                    {
                        objCat.bseleccionado = true;
                    }
                }
            }

            Fdesde = Convert.ToDateTime(obj.fechadesde);
            Fhasta = Convert.ToDateTime(obj.fechahasta);

            BindingContext = this;

        }

        

        private async void btnvolveraveria_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void btnfiltraraveria_Clicked(object sender, EventArgs e)
        {
            //Averias obj = Averias.GetInstance();
            Averias obj = Averias.GetInstance();
            obj.fechadesde = Fdesde.ToString("dd/MM/yyyy");
            obj.fechahasta = Fhasta.ToString("dd/MM/yyyy");

            //List<PaginaCLS> p = oEntityCLS.listaPagina;
            List<ListaEstado> paginasMarcadas = oEntityCLS.Where(pag => pag.bseleccionado == true).ToList();
            obj.listaestado = paginasMarcadas;
            //string cadenaestado = "";
            //foreach (ListaEstado objCat in paginasMarcadas) cadenaestado = cadenaestado + "," + objCat.idestado;
            //cadenaestado = cadenaestado.Substring(1, cadenaestado.Length - 1);

            await Navigation.PopAsync();
            obj.actualizarlista(obj.fechadesde, obj.fechahasta, obj.listaestado);






        }
       
    }
}