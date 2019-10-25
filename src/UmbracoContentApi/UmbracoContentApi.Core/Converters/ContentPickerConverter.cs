using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;
using UmbracoContentApi.Core.Enums;
using UmbracoContentApi.Core.Models;
using UmbracoContentApi.Core.Resolvers;

namespace UmbracoContentApi.Core.Converters
{
    public class ContentPickerConverter : IConverter
    {
        private readonly Lazy<IContentResolver> _contentResolver;

        public ContentPickerConverter(Lazy<IContentResolver> contentResolver)
        {
            _contentResolver = contentResolver;
        }

        /// <inheritdoc />
        public string EditorAlias => "Umbraco.ContentPicker";

        /// <inheritdoc />
        public object Convert(object value, Dictionary<string, object> options = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), $"A value for {EditorAlias} is required.");
            }

            if (options == null)
            {
                return new LinkModel
                {
                    Id = ((IPublishedContent)value).Key,
                    LinkType = LinkType.Content.ToString()
                };
            }

            if (options.ContainsKey("level"))
            {
                var level = options["level"];
                if (int.TryParse(level.ToString(), out int levelNum) && levelNum > 0)
                {
                    options["level"] = levelNum - 1;
                    return _contentResolver.Value.ResolveContent((IPublishedElement)value, options);
                }
            }

            return new LinkModel
            {
                Id = ((IPublishedContent)value).Key,
                LinkType = LinkType.Content.ToString()
            };
        }
    }
}