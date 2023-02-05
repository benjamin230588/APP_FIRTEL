using APP_FIRTEL.Clases;
using APP_FIRTEL.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Utilitarios_Firtel;
using Utilitarios_Firtel.viewmodel;
using Xamarin.Forms;

namespace APP_FIRTEL.ViewModels
{
    public class FormAveriaModel : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        List<string> _listaestado = new List<string>();
        string selectturno;
        DateTime txtfecha;
        //List<AveriaCLS> _ListaAveria;
        #endregion
        #region CONSTRUCTOR
        public FormAveriaModel(INavigation navigation, AveriaCLS objeto)
        {
            Navigation = navigation;
            parametrosRecibe = objeto;
            Listaestado = cargaestado();
            Txtfecha = DateTime.Now;

            //Selectturno = "Pendiente";
        }
        #endregion
        #region OBJETOS
        public AveriaCLS parametrosRecibe { get; set; }
        #endregion



        public List<string> Listaestado
        {
            get { return _listaestado; }
            set { SetValue(ref _listaestado, value); }

        }

        public DateTime Txtfecha
        {
            get { return txtfecha; }

            set { SetValue(ref txtfecha, value); }
        }



        public string Selectturno
        {
            get { return selectturno; }
            set
            {
                SetProperty(ref selectturno, value);
                //Idturno = selectturno;

            }
        }
        //string idturno;
        //public string Idturno
        //{
        //    get { return idturno; }
        //    set { SetValue(ref idturno, value); }
        //}
        public List<string> cargaestado()
        {
            return new List<string>() { "Pendiente", "Proceso", "Realizado" };


        }
        public async Task GrabarAveria()
        {

            if (!string.IsNullOrEmpty(Txtfecha.ToString()))
            {
                //var funcion = new Dsolicitudesrecojo();
                EAveria prueba = new EAveria();
                //var fecha = Txtfecha.ToString("dd-MM-yy");
                var estado = Selectturno;
                var idestado = selectturno == "Pendiente" ? 1 : selectturno == "Proceso" ? 2 :3;
                AveriaCLS objeto = new AveriaCLS();
                
                objeto.usu_creacion = 1;
                objeto.fec_creacion = DateTime.Now;
                objeto.flg_anulado = true;
                objeto.fecha_registro = Txtfecha;
                objeto.Estado = idestado;



                //crear el objeto averia que debo enviar
                Reply res;
                res = await GenericLH.Post<AveriaCLS>(Constantes.url + Constantes.api_grabaraveria, objeto);
                //if (res.result == 1) 
                //{
                await Application.Current.MainPage.DisplayAlert("Datos incompletos", "Seleccine una fecha", "OK");

                
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Datos incompletos", "Seleccine una fecha", "OK");

            }
        } 

        

       

        //#endregion
        //#region COMANDOS
        public ICommand GrabarAveriaComand => new Command(async () => await GrabarAveria());
        //public ICommand Iradetallecommand => new Command<AveriaCLS>(async (p) => await Iradetalle(p));


    }
}
