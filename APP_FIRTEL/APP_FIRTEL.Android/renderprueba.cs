using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
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

[assembly: ExportRenderer(typeof(CustomPicker23), typeof(renderprueba))]

namespace APP_FIRTEL.Droid
{
	public class renderprueba : PickerRenderer
	{
		//CustomPicker element;

		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged(e);

			//if (e.OldElement == null)
			//{
			//	Control.Background = null;
			//}
			//Control.Click += Control_Click;

		}
		public renderprueba(Context context) : base(context)
		{
		}
	}
}