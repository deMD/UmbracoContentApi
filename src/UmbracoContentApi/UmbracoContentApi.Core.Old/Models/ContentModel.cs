using System.Collections.Generic;

namespace UmbracoContentApi.Core.Models
{
    public class ContentModel
    {
        public SystemModel System { get; set; }
        public Dictionary<string, object> Fields { get; set; }
    }
}