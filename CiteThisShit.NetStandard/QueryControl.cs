using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CiteThisShit.Data.Doi;
using CiteThisShit.Data.Book;

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

            var jsonSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var jsonObject = JsonConvert.DeserializeObject<T>(jsonStr, jsonSettings);
            return jsonObject;
        }

        public async Task<DoiResult> QueryDoiResult(string doiString)
        {
            return await _GetDataAsync<DoiResult>("http://api.crossref.org", string.Format("/works/{0}", doiString));
        }

        public async Task<BookResult> QueryIsbnResult(string isbnString)
        {
            string queryPath = string.Format("/books/v1/volumes?q=isbn:{0}", isbnString);
            return await _GetDataAsync<BookResult>("https://www.googleapis.com", queryPath);
        }

        public async Task<BookResult> QueryTitleResult(string titleKeywordString)
        {
            string queryPath = string.Format("/books/v1/volumes?q=intitle:{0}", Uri.EscapeDataString(titleKeywordString));
            return await _GetDataAsync<BookResult>("https://www.googleapis.com", queryPath);
        }
    }
}
