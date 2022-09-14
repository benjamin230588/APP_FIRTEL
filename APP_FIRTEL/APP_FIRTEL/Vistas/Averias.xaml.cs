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
    public partial class Averias : ContentPage
    {
        public List<AveriaCLS> listaCategoria { get; set; }
        public Averias()
        {
            InitializeComponent();
            listaCategoria = new List<AveriaCLS>();
            listaCategoria.Add(new AveriaCLS { idaveria = 1, nombre = "Averia corte de clave de red falta conexion del cliente", fecha = DateTime.Now.ToString("dd/MM/yyyy"), estado = "Pendiente", nombretecnico = "Rafael", cliente = "Mucha Soto Rafael (El Joven)", direccion = "Mercado Ciudad de DIos puerta 12 " });
            listaCategoria.Add(new AveriaCLS { idaveria = 1, nombre = "Averia corte de clave de red falta conexion del cliente", fecha = DateTime.Now.ToString("dd/MM/yyyy"), estado = "Pendiente", nombretecnico = "Rafael", cliente = "Mucha Soto Rafael (El Joven)", direccion = "Mercado Ciudad de DIos puerta 12 " });
            listaCategoria.Add(new AveriaCLS { idaveria = 1, nombre = "Averia corte de clave de red falta conexion del cliente", fecha = DateTime.Now.ToString("dd/MM/yyyy"), estado = "Pendiente", nombretecnico = "Rafael", cliente = "Mucha Soto Rafael (El Joven)", direccion = "Mercado Ciudad de DIos puerta 12 " });
            listaCategoria.Add(new AveriaCLS { idaveria = 1, nombre = "Averia corte de clave de red falta conexion del cliente", fecha = DateTime.Now.ToString("dd/MM/yyyy"), estado = "Pendiente", nombretecnico = "Rafael", cliente = "Mucha Soto Rafael (El Joven)", direccion = "Mercado Ciudad de DIos puerta 12 " });
            listaCategoria.Add(new AveriaCLS { idaveria = 1, nombre = "Averia corte de clave de red falta conexion del cliente", fecha = DateTime.Now.ToString("dd/MM/yyyy"), estado = "Pendiente", nombretecnico = "Rafael", cliente = "Mucha Soto Rafael (El Joven)", direccion = "Mercado Ciudad de DIos puerta 12 " });
            listaCategoria.Add(new AveriaCLS { idaveria = 1, nombre = "Averia corte de clave de red falta conexion del cliente", fecha = DateTime.Now.ToString("dd/MM/yyyy"), estado = "Pendiente", nombretecnico = "Rafael", cliente = "Mucha Soto Rafael (El Joven)", direccion = "Mercado Ciudad de DIos puerta 12 " });
            listaCategoria.Add(new AveriaCLS { idaveria = 1, nombre = "Averia corte de clave de red falta conexion del cliente", fecha = DateTime.Now.ToString("dd/MM/yyyy"), estado = "Pendiente", nombretecnico = "Rafael", cliente = "Mucha Soto Rafael (El Joven)", direccion = "Mercado Ciudad de DIos puerta 12 " });
            listaCategoria.Add(new AveriaCLS { idaveria = 1, nombre = "Averia corte de clave de red falta conexion del cliente", fecha = DateTime.Now.ToString("dd/MM/yyyy"), estado = "Pendiente", nombretecnico = "Rafael", cliente = "Mucha Soto Rafael (El Joven)", direccion = "Mercado Ciudad de DIos puerta 12 " });
            listaCategoria.Add(new AveriaCLS { idaveria = 1, nombre = "Averia corte de clave de red falta conexion del cliente", fecha = DateTime.Now.ToString("dd/MM/yyyy"), estado = "Pendiente", nombretecnico = "Rafael", cliente = "Mucha Soto Rafael (El Joven)", direccion = "Mercado Ciudad de DIos puerta 12 " });
            listaCategoria.Add(new AveriaCLS { idaveria = 1, nombre = "Averia corte de clave de red falta conexion del cliente", fecha = DateTime.Now.ToString("dd/MM/yyyy"), estado = "Pendiente", nombretecnico = "Rafael", cliente = "Mucha Soto Rafael (El Joven)", direccion = "Mercado Ciudad de DIos puerta 12 " });
            listaCategoria.Add(new AveriaCLS { idaveria = 1, nombre = "Averia corte de clave de red falta conexion del cliente", fecha = DateTime.Now.ToString("dd/MM/yyyy"), estado = "Pendiente", nombretecnico = "Rafael", cliente = "Mucha Soto Rafael (El Joven)", direccion = "Mercado Ciudad de DIos puerta 12 " });
            listaCategoria.Add(new AveriaCLS { idaveria = 1, nombre = "Averia corte de clave de red falta conexion del cliente", fecha = DateTime.Now.ToString("dd/MM/yyyy"), estado = "Pendiente", nombretecnico = "Rafael", cliente = "Mucha Soto Rafael (El Joven)", direccion = "Mercado Ciudad de DIos puerta 12 " });
            listaCategoria.Add(new AveriaCLS { idaveria = 1, nombre = "Averia corte de clave de red falta conexion del cliente", fecha = DateTime.Now.ToString("dd/MM/yyyy"), estado = "Pendiente", nombretecnico = "Rafael", cliente = "Mucha Soto Rafael (El Joven)", direccion = "Mercado Ciudad de DIos puerta 12 " });
            listaCategoria.Add(new AveriaCLS { idaveria = 1, nombre = "Averia corte de clave de red falta conexion del cliente", fecha = DateTime.Now.ToString("dd/MM/yyyy"), estado = "Pendiente", nombretecnico = "Rafael", cliente = "Mucha Soto Rafael (El Joven)", direccion = "Mercado Ciudad de DIos puerta 12 " });

            //listaCategoria.Add(new AveriaCLS { idaveria = 2, nombre = "josue" });
            BindingContext = this;


        }

        private void lstCategoria_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new FormAveria());
        }
    }
}