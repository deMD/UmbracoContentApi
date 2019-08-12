using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;
using UmbracoContentApi.Enums;
using UmbracoContentApi.Models;

namespace UmbracoContentApi.Converters
{
    internal class NestedContentConverter : IConverter
    {
        public string EditorAlias => "Umbraco.NestedContent";

        public object Convert(object value)
        {
            var list = new List<LinkModel>();
            foreach (IPublishedElement element in (IEnumerable<IPublishedElement>) value)
            {
                list.Add(
                    new LinkModel
                    {
                        Id = element.Key,
                        LinkType = LinkType.Content.ToString()
                    });
            }

            return list;
        }
    }
}