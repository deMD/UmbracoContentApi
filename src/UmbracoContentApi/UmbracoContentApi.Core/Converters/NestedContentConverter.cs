using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;
using UmbracoContentApi.Core.Models;
using UmbracoContentApi.Core.Resolvers;

namespace UmbracoContentApi.Core.Converters
{
    public class NestedContentConverter : IConverter
    {
        private readonly Lazy<IContentResolver> _contentResolver;

        public NestedContentConverter(Lazy<IContentResolver> contentResolver)
        {
            _contentResolver = contentResolver;
        }

        public string EditorAlias => "Umbraco.NestedContent";

        public object Convert(object value, Dictionary<string, object>? options = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), $"A value for {EditorAlias} is required.");
            }

            var models = new List<ContentModel>();
            foreach (IPublishedElement element in (IEnumerable<IPublishedElement>)value)
            {
                ContentModel model = _contentResolver.Value.ResolveContent(element, options);

                models.Add(model);
            }

            return models;
        }
    }
}