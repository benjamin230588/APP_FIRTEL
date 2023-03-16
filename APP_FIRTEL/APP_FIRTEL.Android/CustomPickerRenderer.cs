using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using APP_FIRTEL.Clases;
using APP_FIRTEL.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Android.Widget.AdapterView;
using static APP_FIRTEL.Droid.CustomPickerRenderer;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace APP_FIRTEL.Droid
{
	public class CustomPickerRenderer : PickerRenderer
	{
		CustomPicker element;
		private Dialog dialog;

		AlertDialog listDialog;
		string[] items;

		private string itemFont;
		private string itemColor;
		private string title;
		private Android.Graphics.Color titleColor;
		private BindingBase displayText;
		

		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged(e);

			element = (CustomPicker)this.Element;

			if (Control != null)
			{
				Control.Click += Control_Click; ;
			}

            //if (Control != null && this.Element != null && !string.IsNullOrEmpty(element.Image))
            //{


               
            //}
            Control.Background = AddPickerStyles();
            //Control.Background = null;
            //Control.Background = AddPickerStyles(element.Image);

            //var customBG = new GradientDrawable();
            //customBG.SetCornerRadius(10);
            //Control.SetBackground(customBG);
            //Control.Click += Control_Click;

            var customPicker =
                (e.NewElement != null) ? (CustomPicker)e.NewElement
                : (e.OldElement != null) ? (CustomPicker)e.OldElement
                : new CustomPicker();

         

            itemColor = !string.IsNullOrWhiteSpace(customPicker.ItemColor)
                ? customPicker.ItemColor : "#000000";

            title = !string.IsNullOrWhiteSpace(customPicker.Title)
                ? customPicker.Title : "Select an item";

            titleColor = customPicker.TitleColor.ToAndroid();
            //displayText = customPicker.ItemDisplayBinding;

        }
		protected override void Dispose(bool disposing)
		{
			Control.Click -= Control_Click;
			base.Dispose(disposing);
		}

		private void Control_Click(object sender, EventArgs e)
		{
            //Picker model = Element;
            ////items = model.ItemsSource;
            //var items = new List<object>();
            //foreach (var item in model.ItemsSource)
            //    items.Add(item);

            //AlertDialog.Builder builder = new AlertDialog.Builder(this.Context);
            //builder.SetTitle(model.Title ?? "");
            //builder.SetNegativeButton("Cancel", (s, a) =>
            //{
            //    Control?.ClearFocus();
            //    builder = null;
            //});

            //Android.Views.View view = LayoutInflater.From(this.Context).Inflate(Resource.Layout.custom_picker_dialog, null);
            //Android.Widget.ListView listView = view.FindViewById<Android.Widget.ListView>(Resource.Id.listview);

            //MyAdapter myAdapter = new MyAdapter(items, Element.SelectedIndex);
            //listView.Adapter = myAdapter;
            //listView.ItemClick += ListView_ItemClick;
            //builder.SetView(view);
            //listDialog = builder.Create();

            //listDialog.Show();
            var model = Element;
            dialog = new Dialog(Forms.Context);
            dialog.SetContentView(Resource.Layout.custom_picker_dialog);

            var textView = (TextView)dialog.FindViewById(Resource.Id.titletextview);
            textView.Text = title;
            textView.SetTextColor(titleColor);

            var items = new List<object>();
            foreach (var item in model.ItemsSource)
                items.Add(item);

            var listView = (Android.Widget.ListView)dialog.FindViewById(Resource.Id.listview);
            listView.Adapter = new MyAdapter(items, itemFont, itemColor);

            listView.ItemClick += (object sender1, ItemClickEventArgs e1) =>
            {
                Control.Text = items.ElementAt(e1.Position).ToString();
                Element.SelectedIndex = e1.Position;
                dialog.Hide();
            };

            if (model.ItemsSource.Count > 2)
            {
                var height = Xamarin.Forms.Application.Current.MainPage.Height;
                var width = Xamarin.Forms.Application.Current.MainPage.Width;
                dialog.Window.SetLayout(700, 600);
            }

            dialog.Show();
        }
        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			Control.Text = items[e.Position];
			Element.SelectedIndex = e.Position;
			Console.WriteLine(items[e.Position]);
			listDialog.Dismiss();
			listDialog = null;
		}
		//	customBG.SetCornerRadius(3);
		public LayerDrawable AddPickerStyles()
		{
			//ShapeDrawable border = new ShapeDrawable();
			//border.Paint.Color = Android.Graphics.Color.Gray;
			//border.SetPadding(10, 10, 10, 10);
			//border.Paint.SetStyle(Paint.Style.Stroke);

			GradientDrawable gd = new GradientDrawable();
			gd.SetCornerRadius(DpToPixels(this.Context,
							Convert.ToSingle(10))); //increase or decrease to changes the corner look  
			gd.SetColor(Android.Graphics.Color.Transparent);
			gd.SetStroke(2, Android.Graphics.Color.Rgb(0, 0, 0));

            Drawable[] layers = { gd};
            LayerDrawable layerDrawable = new LayerDrawable(layers);
            layerDrawable.SetLayerInset(0, 0, 0, 0, 0);

            return layerDrawable;
		}

		private BitmapDrawable GetDrawable(string imagePath)
		{
			int resID = Resources.GetIdentifier(imagePath, "drawable", this.Context.PackageName);
			var drawable = ContextCompat.GetDrawable(this.Context, resID);
			var bitmap = ((BitmapDrawable)drawable).Bitmap;

			var result = new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, 70, 70, true));
			result.Gravity = Android.Views.GravityFlags.Right;

			return result;
		}

		public static float DpToPixels(Context context, float valueInDp)
		{
			DisplayMetrics metrics = context.Resources.DisplayMetrics;
			return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
		}

		

	


	}
    class MyAdapter : BaseAdapter
    {
        private IList<object> mList;
        private Typeface mFont;
        private Android.Graphics.Color mColor;
        private string mDisplay;

        public MyAdapter(IList<object> itemsSource, string font, string color)
        {
            mList = itemsSource;
            //mFont = Typeface.CreateFromAsset(Forms.Context.Assets, font.Split('#')[0]);
            mColor = Android.Graphics.Color.ParseColor(color);
            //mDisplay = ((Binding)display).Path;
        }

        public override int Count => mList.Count;

        public override Java.Lang.Object GetItem(int position)
        {
            var myObj = mList.ElementAt(position);
            return new JavaObjectWrapper<object>() { Obj = myObj };
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Android.Views.View GetView(int position, Android.Views.View view, ViewGroup parent)
        {
            view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cell_layout, null);

            var text = view.FindViewById<TextView>(Resource.Id.textview1);
            //text.Typeface = mFont;
            //if (position==1)
            //{
            //    text.SetTextColor(Android.Graphics.Color.Red);

            //}
            //else if (position==2)
            //{
            //    text.SetTextColor(Android.Graphics.Color.);

            //}
            //else
            //{
            //    text.SetTextColor(mColor);

            //}
            text.SetTextColor(mColor);

            var obj = mList.ElementAt(position);
            text.Text = obj.ToString();
            //obj.GetType().GetProperty(mDisplay).GetValue(obj, null).ToString();

            return view;
        }
    }

    public class JavaObjectWrapper<T> : Java.Lang.Object
	{
		public T Obj { get; set; }
	}

	//class MyAdapter : BaseAdapter
	//{
	//	private List<object> items;
	//	private int selectedIndex;

	//	public MyAdapter(List<object> items)
	//	{
	//		this.items = items;
	//	}

	//	public MyAdapter(List<object> items, int selectedIndex) : this(items)
	//	{
	//		this.selectedIndex = selectedIndex;
	//	}

	//	public override int Count => items.Count;

	//	public override Java.Lang.Object GetItem(int position)
	//	{
	//		return items.ElementAt(position).ToString();
	//	}

	//	public override long GetItemId(int position)
	//	{
	//		return position;
	//	}

	//	public override Android.Views.View GetView(int position, Android.Views.View convertView, ViewGroup parent)
	//	{
 //           if (convertView == null)
 //           {
 //               convertView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cell_layout, null);
 //           }
 //           //convertView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cell_layout, null);

	//		TextView textView = convertView.FindViewById<TextView>(Resource.Id.textview1);
	//		textView.Text = items.ElementAt(position).ToString();
	//		return convertView;
	//	}
	//}
}