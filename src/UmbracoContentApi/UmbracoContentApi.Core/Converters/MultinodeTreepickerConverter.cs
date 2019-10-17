using System;
using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;
using UmbracoContentApi.Core.Models;
using UmbracoContentApi.Core.Resolvers;

namespace UmbracoContentApi.Core.Converters
{
    public class MultinodeTreepickerConverter : IConverter
    {
        public string EditorAlias => "Umbraco.MultiNodeTreePicker";

        public object Convert(object value, params KeyValuePair<string, object>[] options)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), $"A value for {EditorAlias} is required.");
            }

            var list = new List<LinkModel>();
            foreach (IPublishedElement element in (IEnumerable<IPublishedElement>) value)
            {
                list.Add(
                    new LinkModel
                    {
                        Id = element.Key,
                        LinkType = LinkTypeResolver.GetLinkType(element.ContentType.ItemType)
                    });
            }

            return list;
        }
    }
}