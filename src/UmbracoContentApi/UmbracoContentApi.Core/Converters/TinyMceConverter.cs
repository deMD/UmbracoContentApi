using System;
using System.Collections.Generic;
using System.Web;

namespace UmbracoContentApi.Core.Converters
{
    public class TinyMceConverter : IConverter
    {
        public string EditorAlias => "Umbraco.TinyMCE";

        public object Convert(object value, params KeyValuePair<string, object>[] options)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), $"A value for {EditorAlias} is required.");
            }

            if (value is IHtmlString htmlString)
            {
                return htmlString.ToHtmlString();
            }

            return default;
        }
    }
}