using APP_FIRTEL.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Utilitarios_App.viewmodel;
using Xamarin.Forms;

namespace APP_FIRTEL.ViewModels
{
    public class ClienteModel : BaseBinding
    {

        private List<ECliente> _listaCategoria;
        //public ClienteModel oEntityCLS { get; set; }

        public List<ECliente> listaCategoria
        {
            get { return _listaCategoria; }
            set { SetValue(ref _listaCategoria, value); }
        }

        private ImageSource _Imagen;
        public ImageSource Imagen
        {
            get { return _Imagen; }
            set { SetValue(ref _Imagen, value); }
        }


        //private List<EClientes> _listaCategoria;
        //public List<EClientes> listaCategoria
        //{
        //    get { return _listaCategoria ?? _listaCategoria == new List<EClientes>; }
        //    set
        //    {
        //        if (_listaCategoria != value)
        //        {
        //            _listaCategoria = value;
        //            //SetPropertyChanged();
        //            //this._IsLoading = value;
        //            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.listaCategoria)));
        //        }
        //    }
        //}

        //public event PropertyChangedEventHandler PropertyChanged;
    }
}
