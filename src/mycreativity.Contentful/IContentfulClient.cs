using System.Collections.Generic;
using System.Threading.Tasks;
using mycreativity.Contentful.Models;

namespace mycreativity.Contentful
{
    public interface IContentfulClient
    {
        Task<Entry<dynamic>> GetEntryAsync(string entryId);
        Task<T> GetEntryAsync<T>(string entryId) where T : EntryBase;
        Task<SearchResult<Entry<dynamic>>> SearchEntriesAsync(Dictionary<string, object> parameters);
        Task<SearchResult<T>> SearchEntriesAsync<T>(Dictionary<string, object> parameters) where T : EntryBase;
    }
}