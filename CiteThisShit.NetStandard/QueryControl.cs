using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CiteThisShit.Data.Doi;
using CiteThisShit.Data.GoogleBook;
using CiteThisShit.Data.OpenLibrary;

namespace CiteThisShit.NetStandard
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

        public async Task<DoiResult> QueryDoiResult(string doiString)
        {
            return await _GetDataAsync<DoiResult>("http://api.crossref.org", string.Format("/works/{0}", doiString));
        }

        public async Task<GoogleBookResult> QueryGoogleIsbnResult(string isbnString)
        {
            string queryPath = string.Format("/books/v1/volumes?q=isbn:{0}", isbnString);
            return await _GetDataAsync<GoogleBookResult>("https://www.googleapis.com", queryPath);
        }

        public async Task<GoogleBookResult> QueryGoogleTitleResult(string titleKeywordString)
        {
            string queryPath = string.Format("/books/v1/volumes?q=intitle:{0}", Uri.EscapeDataString(titleKeywordString));
            return await _GetDataAsync<GoogleBookResult>("https://www.googleapis.com", queryPath);
        }

        public async Task<OpenLibraryResult> QueryOpenLibraryIsbnResult(string isbnString)
        {
            string queryPath = string.Format("/api/books?bibkeys=ISBN:{0}&jscmd=details&format=json", isbnString);
            var result = await _GetDataAsync<Dictionary<string, OpenLibraryResult>>("https://openlibrary.org", queryPath);
            return result["ISBN:" + isbnString];
        }
    }
}
