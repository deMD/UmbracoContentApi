using System;

namespace UmbracoContentApi.Core.Models
{
    public class SystemModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string UrlSegment { get; set; } 

        public string Type { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime EditedAt { get; set; }

        public int Revision { get; set; }

        public string ContentType { get; set; }

        public string Locale { get; set; }
    }
}