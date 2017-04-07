using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CiteThisShit.MacLib
{
	public class QueryControl
	{
		private HttpClient _HttpClient(string baseAddress)
		{
			var client = new HttpClient()
			{
				BaseAddress = new Uri(baseAddress)

			};

			return client;
		}

		private async Task<T> _GetDataAsync<T>(string baseUrl, string queryPath)
		{
			var client = _HttpClient(baseUrl);
			string jsonStr = await client.GetStringAsync(queryPath);
			client.Dispose();

			var jsonObject = JsonConvert.DeserializeObject<T>(jsonStr);
			return jsonObject;
		}

		public async Task<Data.Doi.DoiResult> QueryDoiResult(string doiString)
		{
			return await _GetDataAsync<Data.Doi.DoiResult>("http://api.crossref.org", string.Format("/works/{0}", doiString));
		}

		public async Task<Data.GoogleBook.GoogleBookResult> QueryGoogleIsbnResult(string isbnString)
		{
			string queryPath = string.Format("/books/v1/volumes?q=isbn:{0}", isbnString);
			return await _GetDataAsync<Data.GoogleBook.GoogleBookResult>("https://www.googleapis.com", queryPath);
		}

		public async Task<Data.GoogleBook.GoogleBookResult> QueryGoogleTitleResult(string titleKeywordString)
		{
			string queryPath = string.Format("/books/v1/volumes?q=intitle:{0}", Uri.EscapeDataString(titleKeywordString));
			return await _GetDataAsync<Data.GoogleBook.GoogleBookResult>("https://www.googleapis.com", queryPath);
		}

		public async Task<Data.OpenLibrary.OpenLibraryResult> QueryOpenLibraryIsbnResult(string isbnString)
		{
			string queryPath = string.Format("/api/books?bibkeys=ISBN:{0}&jscmd=details&format=json", isbnString);
			var result = await _GetDataAsync<Dictionary<string, Data.OpenLibrary.OpenLibraryResult>>("https://openlibrary.org", queryPath);
			return result["ISBN:" + isbnString];
		}
	}
}
