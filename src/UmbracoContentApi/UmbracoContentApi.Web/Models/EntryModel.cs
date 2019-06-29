using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoContentApi.Web.Models
{
    public class EntryModel
    {
        public SystemModel System { get; set; }
        public Dictionary<string,object> Fields { get; set; }
    }
}