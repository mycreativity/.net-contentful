using mycreativity.Contentful.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace mycreativity.Contentful
{
    public class ContentfulClient : IContentfulClient
    {
        private readonly string space;
        private readonly IHttpClientWrapper httpClient;

        public ContentfulClient(string space, string accessToken)
        {
            this.space = space;
            this.httpClient = createHttpClient("cdn.contentful.com", accessToken);
        }

        public ContentfulClient(string space, string accessToken, string host)
        {
            this.space = space;
            this.httpClient = createHttpClient(host, accessToken);
        }

        public async Task<Entry> GetEntryAsync(string entryId)
        {
            Entry entry;
            string requestUri = $"spaces/{this.space}/entries/{entryId}";
            using (HttpResponseMessage response = await httpClient.GetAsync(requestUri))
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();
                entry = await Task.Factory.StartNew<Entry>(() => JsonConvert.DeserializeObject<Entry>(result));
            }

            return entry;
        }

        public async Task<SearchResult> SearchEntriesAsync(Dictionary<string, object> parameters) {
            SearchResult searchResult;
            string queryString = string.Join("&", parameters.Select(kvp => $"{kvp.Key}={kvp.Value}"));
            string requestUri = $"spaces/{this.space}/entries?{queryString}";
            
            using (HttpResponseMessage response = await httpClient.GetAsync(requestUri))
            using (HttpContent content = response.Content) {
                string result = await content.ReadAsStringAsync();
                searchResult = await Task.Factory.StartNew<SearchResult>(() => JsonConvert.DeserializeObject<SearchResult>(result));
            }

            return searchResult;
        }

        private HttpClientWrapper createHttpClient(string host, string accessToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            httpClient.BaseAddress = new Uri($"https://{host}/");
            return new HttpClientWrapper(httpClient);
        }
    }
}
