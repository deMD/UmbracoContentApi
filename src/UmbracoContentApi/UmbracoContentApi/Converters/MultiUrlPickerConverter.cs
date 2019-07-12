using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;
using UmbracoContentApi.Models;

namespace UmbracoContentApi.Converters
{
    internal class MultiUrlPickerConverter : IConverter
    {
        public string EditorAlias => "Umbraco.MultiUrlPicker";

        public object Convert(object value)
        {
            var links = new List<MulitLinkModel>();
            foreach (Link link in ((IEnumerable<object>) value))
            {
                links.Add(new MulitLinkModel
                {
                    Name = link.Name,
                    Target = link.Target,
                    Type = ((MulitLinkModel.ContentType)(int)link.Type).ToString(),
                    Url = link.Url
                });
            }

            return links;
        }
    }
}
