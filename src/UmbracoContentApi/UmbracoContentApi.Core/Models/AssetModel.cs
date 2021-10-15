using System.Collections.Generic;

namespace UmbracoContentApi.Core.Models
{
    public class AssetModel
    {
        public SystemModel? System { get; set; }
        public Dictionary<string, object>? Fields { get; set; }
    }
}