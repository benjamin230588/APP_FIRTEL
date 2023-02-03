using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace APP_FIRTEL.Clases
{
    public class ExtendedDatePicker : DatePicker
    {
        private string _format = null;
        public static readonly BindableProperty NullableDateProperty = BindableProperty.Create<ExtendedDatePicker, DateTime?>(p => p.NullableDate, null);

        public DateTime? NullableDate
        {
            get { return (DateTime?)GetValue(NullableDateProperty); }
            set { SetValue(NullableDateProperty, value); UpdateDate(); }
        }

        private void UpdateDate()
        {
            if (NullableDate.HasValue) 
            { if (null != _format) Format = _format; Date = NullableDate.Value; }
            else { _format = Format; Format = "Seleccione"; }
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            UpdateDate();
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == "Date") NullableDate = Date;
        }
    }

}

