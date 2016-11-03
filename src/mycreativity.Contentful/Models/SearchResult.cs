using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mycreativity.Contentful.Models
{
    public class SearchResult<T>  where T : EntryBase
    {
        public Entry<T>[] Items { get; set; }
    }
}
