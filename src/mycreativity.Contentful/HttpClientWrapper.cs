using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace mycreativity.Contentful
{
    internal class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _baseClient;

        internal HttpClientWrapper(HttpClient baseClient)
        {
            _baseClient = baseClient;
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return await _baseClient.GetAsync(requestUri);
        }
    }
}