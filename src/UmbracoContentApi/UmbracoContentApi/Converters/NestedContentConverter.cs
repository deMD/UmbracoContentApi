using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;
using UmbracoContentApi.Models;

namespace UmbracoContentApi.Converters
{
    internal class NestedContentConverter : IConverter
    {
        public string EditorAlias => "Umbraco.NestedContent";

        public object Convert(object value)
        {
            var list = new List<LinkModel>();
            foreach (var element in (IEnumerable<IPublishedElement>)value)
            {
                list.Add(new LinkModel
                {
                    Id = element.Key,
                    LinkType = "Entry"
                });
            }

            return list;
        }
    }
}
