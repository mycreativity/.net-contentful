using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mycreativity.Contentful.Models
{
    public class Entry<T> : EntryBase
    {
        public T Fields { get; set; }
    }
}
