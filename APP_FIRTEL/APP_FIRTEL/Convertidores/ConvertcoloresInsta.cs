using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace APP_FIRTEL.Convertidores
{
    class ConvertcoloresInsta : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // string colorDevolver = "";
            Color colorDevolver = Color.Transparent;
            int colorvalor = (int)value;

            switch (colorvalor)
            {
                case 1:
                    colorDevolver = Color.Red;
                    break;
                case 2:
                    colorDevolver = Color.Orange;
                    break;
                case 3:
                    colorDevolver = Color.Blue;
                    break;
                case 4:
                    colorDevolver = Color.Green;
                    break;

            }
            return colorDevolver;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
