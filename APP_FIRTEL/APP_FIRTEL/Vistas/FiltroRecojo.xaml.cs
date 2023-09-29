using APP_FIRTEL.Clases;
using APP_FIRTEL.Genericos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APP_FIRTEL.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FiltroRecojo : ContentPage
    {
        public List<ListaEstado> oEntityCLS { get; set; }
        public DateTime Fdesde { get; set; }
        public string namezona { get; set; }
        public DateTime Fhasta { get; set; }
        public FiltroRecojo()
        {
            InitializeComponent();
            int idtipousuario = Setings.IdTipoUsuario;
            if (idtipousuario == 1)
            {
                oEntityCLS = new List<ListaEstado>(){
                new ListaEstado () { idestado=1 , nombre="Pendiente" ,bseleccionado=false},
                new ListaEstado () { idestado=2 , nombre="Proceso" , bseleccionado=false},
                new ListaEstado () { idestado=3 , nombre="Realizado"  ,bseleccionado=false},
                new ListaEstado () { idestado=4 , nombre="Cerrado" , bseleccionado=false},
            };
            }
            else
            {
                oEntityCLS = new List<ListaEstado>(){
                new ListaEstado () { idestado=1 , nombre="Pendiente" ,bseleccionado=false},
                new ListaEstado () { idestado=2 , nombre="Proceso" , bseleccionado=false},
                new ListaEstado () { idestado=3 , nombre="Realizado"  ,bseleccionado=false},

            };

            }

            Recojos obj = Recojos.GetInstance();
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

            //Fdesde = Convert.ToDateTime(obj.fechadesde);
            DateTime.TryParseExact(obj.fechadesde,             //Primero la variable
                                                     "dd/MM/yyyy",         //El formato esperado
                                                     CultureInfo.InvariantCulture, //Información de cultura
                                                     DateTimeStyles.None,  //Formato de análisis
                                                     out DateTime Fdesde1);
            DateTime.TryParseExact(obj.fechahasta,             //Primero la variable
                                                     "dd/MM/yyyy",         //El formato esperado
                                                     CultureInfo.InvariantCulture, //Información de cultura
                                                     DateTimeStyles.None,  //Formato de análisis
                                                     out DateTime Fhasta1);

            Fdesde = Fdesde1;
            Fhasta = Fhasta1;
            namezona = obj.namezona;
            BindingContext = this;

        }



        private async void btnvolverrecojo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void btnfiltrarrecojo_Clicked(object sender, EventArgs e)
        {
            List<ListaEstado> paginasMarcadas = oEntityCLS.Where(pag => pag.bseleccionado == true).ToList();
            if (paginasMarcadas.Count > 0)
            {
                var difere = Fhasta - Fdesde;
                var diferedias = difere.Days;

                if (diferedias >= 0)
                {
                    //Averias obj = Averias.GetInstance();
                    Recojos obj = Recojos.GetInstance();
                    obj.fechadesde = Fdesde.ToString("dd/MM/yyyy");
                    obj.fechahasta = Fhasta.ToString("dd/MM/yyyy");
                    obj.namezona = namezona;

                    //List<PaginaCLS> p = oEntityCLS.listaPagina;
                    obj.listaestado = paginasMarcadas;
                    //string cadenaestado = "";
                    //foreach (ListaEstado objCat in paginasMarcadas) cadenaestado = cadenaestado + "," + objCat.idestado;
                    //cadenaestado = cadenaestado.Substring(1, cadenaestado.Length - 1);

                    await Navigation.PopAsync();
                    obj.actualizarlista(obj.fechadesde, obj.fechahasta, obj.listaestado,obj.namezona);

                }
                else
                {
                    await DisplayAlert("Error", "Fecha desde no debe ser mayor a Hasta", "Cancelar");

                }



            }
            else
            {
                await DisplayAlert("Error", "Debe de seleccionar un Estado", "Cancelar");

            }


        }
    }
}