using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbracoContentApi.Models
{
    internal class MulitLinkModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string Target { get; set; }

        public string Type { get; set; }

        internal enum ContentType
        {
            Entry,
            Asset,
            External
        }
    }
}
