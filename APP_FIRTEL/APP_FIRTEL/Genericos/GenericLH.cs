using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Xamarin.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using System.Collections.ObjectModel;
using Plugin.Media.Abstractions;
using Utilitarios_App;

namespace APP_FIRTEL.Generic
{
	public class GenericLH
	{
		

		public static async Task<int> Delete(string url)
		{
			HttpClient cliente = new HttpClient();
			var rpta = await cliente.DeleteAsync(url);
			if (!rpta.IsSuccessStatusCode) return 0;
			else
			{
				//Cadena(1 -> Exitoso , 0->Error) ->int ""
				var result = await rpta.Content.ReadAsStringAsync();
				return int.Parse(result);
			}


		}

		//Retorne la data
		public static async Task<Reply> GetAll<M>(string url, M obj)
		{
			HttpClient cliente = new HttpClient();
			//var rpta = await cliente.GetAsync(url);

			var cadena = JsonConvert.SerializeObject(obj);
			var body = new StringContent(cadena, Encoding.UTF8, "application/json");
			var rpta = await cliente.PostAsync(url, body);
			if (!rpta.IsSuccessStatusCode) return new Reply { result = 0 }; 
			else
			{
				//Como String
				var result = await rpta.Content.ReadAsStringAsync();
				//List<T> l = JsonConvert.DeserializeObject<List<L>>(result);
				Reply res = JsonConvert.DeserializeObject<Reply>(result);
				return res;
			}

		}


		public static async Task<T> Get<T>(string url)
		{
			HttpClient cliente = new HttpClient();
			var rpta = await cliente.GetAsync(url);
			
				//Como String
				var result = await rpta.Content.ReadAsStringAsync();
				T l = JsonConvert.DeserializeObject<T>(result);
				return l;
			

		}

		public static  async Task<Reply> Post<T>(string url, T obj)
		{
			HttpClient cliente = new HttpClient();
			var cadena = JsonConvert.SerializeObject(obj);
			var body = new StringContent(cadena, Encoding.UTF8, "application/json");
			//cliente.he
			var response = await cliente.PostAsync(url, body);
			if (!response.IsSuccessStatusCode) return new Reply { result = 0 };
			else
			{
				//int respuesta = int.Parse(await response.Content.ReadAsStringAsync());
				var result = await response.Content.ReadAsStringAsync();
				Reply res = JsonConvert.DeserializeObject<Reply>(result);
				return res;
			}


		}

		public static ObservableCollection<T> ToCollection<T>(List<T> items)
		{
			ObservableCollection<T> collection = new ObservableCollection<T>();

			for (int i = 0; i < items.Count; i++)
			{
				collection.Add(items[i]);
			}

			return collection;
		}
		public static ImageSource convertirMediaFileAImageSource(MediaFile media)
		{
			return ImageSource.FromStream(() =>
			{
				return media.GetStream();
			});
		}

		public static ImageSource convertirArrayDeBytesAImageSource(byte[] arraybytes)
		{
			//byte[] buffer = Convert.FromBase64String(base64);
			///MemoryStream ms = new MemoryStream(arraybytes);
			return ImageSource.FromStream(() => new MemoryStream(arraybytes));
		}


	}
}
