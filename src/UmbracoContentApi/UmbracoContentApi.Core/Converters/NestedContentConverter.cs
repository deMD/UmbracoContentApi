using System;
using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;
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

        public object Convert(object value, params KeyValuePair<string, object>[] options)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), $"A value for {EditorAlias} is required.");
            }

            var models = new List<ContentModel>();
            foreach (var element in (IEnumerable<IPublishedElement>) value)
            {
                var model = _contentResolver.Value.ResolveContent(element);

                models.Add(model);
            }

            return models;
        }
    }
}