using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbracoContentApi.Models
{
    public class LinkModel
    {
        public Guid Id { get; set; }

        public string LinkType { get; set; }

        public string Type => "Link";
    }
}
