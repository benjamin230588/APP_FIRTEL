using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Service.Controls;
using Android.Util;
using Android.Views;
using Android.Widget;
using APP_FIRTEL.Clases;
using APP_FIRTEL.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CurvedLabelRenderer))]
namespace APP_FIRTEL.Droid
{
    class CurvedLabelRenderer : LabelRenderer
    {
        private GradientDrawable _gradientBackground;
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            var view = (CustomLabel)Element;
            if (view == null) return;
            // creating gradient drawable for the curved background  
            _gradientBackground = new GradientDrawable();

            _gradientBackground.SetShape(ShapeType.Rectangle);
            _gradientBackground.SetColor(view.BackgroundColor.ToAndroid());


            // Thickness of the stroke line
            _gradientBackground.SetStroke(view.BorderWidth, view.BorderColor.ToAndroid());

            _gradientBackground.SetCornerRadius(DpToPixels(this.Context,
                Convert.ToSingle(view.CurvedCornerRadius)));

            // set the background of the label  
            Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            Control.SetBackground(_gradientBackground);
            
            Control.SetTextIsSelectable(true);
        }
        //Px to Dp Conver  
        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}


//private GradientDrawable _gradientBackground;
//protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
//{
//    base.OnElementChanged(e);
//    var view = (CustomLabel)Element;
//    if (view == null) return;
//    // creating gradient drawable for the curved background  
//    _gradientBackground = new GradientDrawable();
//    _gradientBackground.SetShape(ShapeType.Rectangle);
//    _gradientBackground.SetColor(view.CurvedBackgroundColor.ToAndroid());

//    // Thickness of the stroke line  
//    _gradientBackground.SetStroke(4, view.CurvedBackgroundColor.ToAndroid());

//    // Radius for the curves  
//    _gradientBackground.SetCornerRadius(DpToPixels(this.Context,
//        Convert.ToSingle(view.CurvedCornerRadius)));

//    // set the background of the label  
//    Control.SetBackground(_gradientBackground);
//}
////Px to Dp Conver  
//public static float DpToPixels(Context context, float valueInDp)
//{
//    DisplayMetrics metrics = context.Resources.DisplayMetrics;
//    return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
//}  
//    }  