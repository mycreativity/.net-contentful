using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace mycreativity.Contentful
{
    internal interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
    }
}
