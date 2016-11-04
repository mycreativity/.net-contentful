using System;

namespace mycreativity.Contentful.Models
{
    public class Sys
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Type { get; set; }
        public int Revision { get; set; }
        public string Locale { get; set; }
    }
}