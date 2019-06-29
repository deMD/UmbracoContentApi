using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoContentApi.Web.Models
{
    public class SystemModel
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime EditedAt { get; set; }

        public int Revision { get; set; }

        public string ContentType { get; set; }

        public string Locale { get; set; }
    }
}