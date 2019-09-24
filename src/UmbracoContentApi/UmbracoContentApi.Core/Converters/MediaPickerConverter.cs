using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using UmbracoContentApi.Core.Resolvers;

namespace UmbracoContentApi.Core.Converters
{
    public class MediaPickerConverter : IConverter
    {
        private readonly Lazy<IContentResolver> _contentResolver;

        public MediaPickerConverter(Lazy<IContentResolver> contentResolver)
        {
            _contentResolver = contentResolver;
        }

        public string EditorAlias => "Umbraco.MediaPicker";

        public object Convert(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), $"A value for {EditorAlias} is required.");
            }

            if (value is IEnumerable<IPublishedContent> ar)
            {
                return ar.Select(t => _contentResolver.Value.ResolveContent(t)).ToList();
            }

            return _contentResolver.Value.ResolveContent((IPublishedElement)value);
        }
    }
}