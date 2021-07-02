using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using UmbracoContentApi.Core.Resolvers;

namespace UmbracoContentApi.Core.Converters
{
    public class MediaPicker3Converter : IConverter
    {
        private readonly Lazy<IContentResolver> _contentResolver;

        public MediaPicker3Converter(Lazy<IContentResolver> contentResolver)
        {
            _contentResolver = contentResolver;
        }

        public string EditorAlias => "Umbraco.MediaPicker3";

        public object Convert(object value, Dictionary<string, object> options = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), $"A value for {EditorAlias} is required.");
            }

            if (value is IEnumerable<MediaWithCrops> ar)
            {
                return ar.Select(t => _contentResolver.Value.ResolveContent(t.MediaItem, options)).ToList();
            }

            return _contentResolver.Value.ResolveContent(((MediaWithCrops)value).MediaItem, options);
        }
    }
}