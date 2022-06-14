using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
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

[assembly: ExportRenderer(typeof(BorderedEditor), typeof(BorderedEditorRenderer))]
namespace APP_FIRTEL.Droid
{
    public class BorderedEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            var view = (BorderedEditor)Element;
            if (Control != null)
            {
                var _gradientBackground = new GradientDrawable();
                _gradientBackground.SetShape(ShapeType.Rectangle);
                _gradientBackground.SetColor(view.BackgroundColor.ToAndroid());


                // Thickness of the stroke line
                _gradientBackground.SetStroke(view.BorderWidth, view.BorderColor.ToAndroid());

                // Radius for the curves
                _gradientBackground.SetCornerRadius(
                    DpToPixels(this.Context,
                        Convert.ToSingle(view.CornerRadius)));


                // set the background of the label
                //Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
                Control.SetBackground(_gradientBackground);
                //Control.Background = null;

                //var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
                //layoutParams.SetMargins(0, 0, 0, 0);
                //LayoutParameters = layoutParams;
                //Control.LayoutParameters = layoutParams;
                //Control.SetPadding(0, 0, 0, 0);
                //SetPadding(0, 0, 0, 0);
            }
        }
        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}