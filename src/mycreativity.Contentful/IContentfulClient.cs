using mycreativity.Contentful.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mycreativity.Contentful
{
    public interface IContentfulClient
    {
        Task<Entry> GetEntryAsync(string entryId);
        Task<SearchResult> SearchEntriesAsync(Dictionary<string, object> parameters);
    }
}
