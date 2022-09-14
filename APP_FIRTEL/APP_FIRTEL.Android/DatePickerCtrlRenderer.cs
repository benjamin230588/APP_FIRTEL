using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using APP_FIRTEL.Clases;
using APP_FIRTEL.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(DatePickerCtrl), typeof(DatePickerCtrlRenderer))]
namespace APP_FIRTEL.Droid
{
    public class DatePickerCtrlRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            this.Control.SetTextColor(Android.Graphics.Color.Rgb(0,0,0));
            this.Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            this.Control.SetPadding(20, 0, 0, 0);

            GradientDrawable gd = new GradientDrawable();
            gd.SetCornerRadius(DpToPixels(this.Context,
                            Convert.ToSingle(10))); //increase or decrease to changes the corner look  
            gd.SetColor(Android.Graphics.Color.Transparent);
            gd.SetStroke(2, Android.Graphics.Color.Rgb(0,0,0));

            this.Control.SetBackgroundDrawable(gd);

            DatePickerCtrl element = Element as DatePickerCtrl;

            if (!string.IsNullOrWhiteSpace(element.Placeholder))
            {
                Control.Text = element.Placeholder;
            }

            this.Control.TextChanged += (sender, arg) => {
                var selectedDate = arg.Text.ToString();
                if (selectedDate == element.Placeholder)
                {
                    Control.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
            };
        }
        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}