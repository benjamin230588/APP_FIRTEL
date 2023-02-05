using APP_FIRTEL.Generic;
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
        private string _usuario;
        private string _pasword;

        public bool flgindicador
        {
            get { return _flgindicador; }
            set { SetValue(ref _flgindicador, value); }
        }

        //public string usuario
        //{
        //    get { return _usuario; }
        //    set { SetValue(ref _usuario, value); }
        //}
       //public string pasword
        //{
        //    get { return _pasword; }
        //    set { SetValue(ref _pasword, value); }
        //} 

        public string usuario
        {
            get { return _usuario; }
            set { _usuario=value; }
        }
        public string pasword
        {
            get { return _pasword; }
            set { _pasword = value; }
        }
    }
}
