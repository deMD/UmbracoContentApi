using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using UmbracoContentApi.Core.Models;
using UmbracoContentApi.Core.Resolvers;

namespace UmbracoContentApi.Core.Converters
{
    public class MultinodeTreepickerConverter : IConverter
    {
        private readonly Lazy<IContentResolver> _contentResolver;

        public MultinodeTreepickerConverter(Lazy<IContentResolver> contentResolver)
        {
            _contentResolver = contentResolver;
        }

        public string EditorAlias => "Umbraco.MultiNodeTreePicker";

        public object Convert(object value, Dictionary<string, object> options = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), $"A value for {EditorAlias} is required.");
            }

            int levelNum;
            if (value is IPublishedElement element)
            {
                if (options == null || !options.ContainsKey("level"))
                {
                    return GetLinkModel(element);
                }
                
                if (!int.TryParse(options["level"].ToString(), out levelNum) || levelNum <= 0)
                {
                    return GetLinkModel(element);
                }

                options["level"] = levelNum - 1;
                return _contentResolver.Value.ResolveContent(element, options);
            }


            if (options == null || !options.ContainsKey("level"))
            {
                return ((IEnumerable<IPublishedElement>)value)
                    .Select(GetLinkModel)
                    .ToList();
            }
            
            if (!int.TryParse(options["level"].ToString(), out levelNum) || levelNum <= 0)
            {
                return ((IEnumerable<IPublishedElement>)value)
                    .Select(GetLinkModel)
                    .ToList();
            }

            options["level"] = levelNum - 1;
            return ((IEnumerable<IPublishedElement>)value).Select(
                x => _contentResolver.Value.ResolveContent(x, options));

        }

        private static LinkModel GetLinkModel(IPublishedElement element)
        {
            return new LinkModel
            {
                Id = element.Key,
                LinkType = LinkTypeResolver.GetLinkType(element.ContentType.ItemType)
            };
        }
    }
}