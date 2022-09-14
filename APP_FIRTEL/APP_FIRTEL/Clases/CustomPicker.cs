using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace APP_FIRTEL.Clases
{
	public class CustomPicker : Picker
	{
		public static readonly BindableProperty ImageProperty =
			BindableProperty.Create(nameof(Image), typeof(string), typeof(CustomPicker), string.Empty);

		public string Image
		{
			get { return (string)GetValue(ImageProperty); }
			set { SetValue(ImageProperty, value); }
		}

		//public static readonly BindableProperty ItemFontFamilyProperty =
		//		BindableProperty.Create("ItemFontFamily", typeof(string), typeof(CustomPicker), defaultBindingMode: BindingMode.OneWay);

		//public string ItemFontFamily
		//{
		//	get { return (string)GetValue(ItemFontFamilyProperty); }
		//	set { SetValue(ItemFontFamilyProperty, value); }
		//}

		public static readonly BindableProperty ItemColorProperty =
				BindableProperty.Create("ItemColor", typeof(string), typeof(CustomPicker), defaultBindingMode: BindingMode.OneWay);

		public string ItemColor
		{
			get { return (string)GetValue(ItemColorProperty); }
			set { SetValue(ItemColorProperty, value); }
		}
	}

	public class CustomPicker23 : Picker
	{
		public CustomPicker23() : base()
		{
		}
	}


}
