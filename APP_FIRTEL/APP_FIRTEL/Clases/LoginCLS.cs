using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace APP_FIRTEL.Clases
{
    public class LoginCLS : INotifyPropertyChanged
    {
        public bool flgindicador { get; set; }
        public bool flgindicadormetodo
        {
            get { return flgindicador; }
            set
            {
                if (this.flgindicador != value)
                {
                    this.flgindicador = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.flgindicadormetodo)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
