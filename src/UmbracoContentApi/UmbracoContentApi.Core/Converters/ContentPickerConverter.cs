using System;
using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;
using UmbracoContentApi.Core.Enums;
using UmbracoContentApi.Core.Models;

namespace UmbracoContentApi.Core.Converters
{
    public class ContentPickerConverter : IConverter
    {
        public string EditorAlias => "Umbraco.ContentPicker";

        public object Convert(object value, params KeyValuePair<string, object>[] options)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), $"A value for {EditorAlias} is required.");
            }

            return new LinkModel
            {
                Id = ((IPublishedContent) value).Key,
                LinkType = LinkType.Content.ToString()
            };
        }
    }
}