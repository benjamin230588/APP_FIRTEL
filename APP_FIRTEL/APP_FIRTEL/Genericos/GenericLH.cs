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

namespace MiPrimeraAplicacionEnXamarinForm.Generic
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
		public static async Task<List<T>> GetAll<T>(string url)
		{
			HttpClient cliente = new HttpClient();
			var rpta = await cliente.GetAsync(url);
			if (!rpta.IsSuccessStatusCode) return new List<T>() ;
			else
			{
				//Como String
				var result = await rpta.Content.ReadAsStringAsync();
				List<T> l = JsonConvert.DeserializeObject<List<T>>(result);
				return l;
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


	}
}
