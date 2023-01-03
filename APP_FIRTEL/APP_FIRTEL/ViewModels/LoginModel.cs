using MiPrimeraAplicacionEnXamarinForm.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace APP_FIRTEL.ViewModels
{
    public class LoginModel : BaseBinding
    {
        //private bool _flgindicador;
        //private string nombre1;

        //public bool flgindicador
        //{
        //    get { return _flgindicador; }
        //    set { SetValue(ref _flgindicador, value); }
        //}
        private bool _flgindicador;
        private string nombre1;

        public bool flgindicador
        {
            get { return _flgindicador; }
            set { SetValue(ref _flgindicador, value); }
        }
        //public int idaveria { get; set; }
        //public string nombre
        //{
        //    get => nombre1; 
        //    set
        //    {
        //        nombre1 = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public event PropertyChangedEventHandler PropertyChanged;
        //protected virtual void OnPropertyChanged([CallerMemberName] string name = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        //}
    }
}
