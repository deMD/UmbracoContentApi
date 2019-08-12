using System;

namespace UmbracoContentApi.Models
{
    public class LinkModel
    {
        public Guid Id { get; set; }

        public string LinkType { get; set; }

        public string Type => "Link";
    }
}