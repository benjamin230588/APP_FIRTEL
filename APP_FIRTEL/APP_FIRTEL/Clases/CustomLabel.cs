using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace APP_FIRTEL.Clases
{
    public class CustomLabel :Label
    {
        public static readonly BindableProperty CornerRadiusProperty =
       BindableProperty.Create(
           nameof(CornerRadius),
           typeof(double),
           typeof(CustomEntry),
           Device.OnPlatform<double>(6, 7, 7));

        // Gets or sets CornerRadius value
        public double CurvedCornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        //public double CurvedCornerRadius
        //{
        //    get { return (double)GetValue(CurvedCornerRadiusProperty); }
        //    set { SetValue(CurvedCornerRadiusProperty, value); }
        //}

        //public static readonly BindableProperty CurvedBackgroundColorProperty =
        //    BindableProperty.Create(
        //        nameof(CurvedCornerRadius),
        //        typeof(Color),
        //        typeof(CustomLabel),
        //        Color.Default);





        public static readonly BindableProperty BorderColorProperty =
       BindableProperty.Create(
           nameof(BorderColor),
           typeof(Color),
           typeof(CustomEntry),
           Color.Black);

        // Gets or sets BorderColor value
        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty BorderWidthProperty =
        BindableProperty.Create(
            nameof(BorderWidth),
            typeof(int),
            typeof(CustomEntry),
            Device.OnPlatform<int>(1, 2, 2));

        // Gets or sets BorderWidth value
        public int BorderWidth
        {
            get { return (int)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }
    }
}
