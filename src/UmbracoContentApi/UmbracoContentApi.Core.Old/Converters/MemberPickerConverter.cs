using System;
using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;

namespace UmbracoContentApi.Core.Converters
{
    public class MemberPickerConverter : IConverter
    {
        public string EditorAlias => "Umbraco.MemberPicker";

        public object Convert(object value, Dictionary<string, object> options = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), $"A value for {EditorAlias} is required.");
            }

            return ((IPublishedContent)value).Name;
        }
    }
}
