using System;
using System.Collections.Generic;
using System.Web;

namespace UmbracoContentApi.Core.Converters
{
    public class TinyMceConverter : IConverter
    {
        public string EditorAlias => "Umbraco.TinyMCE";

        public object Convert(object value, Dictionary<string, object> options = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), $"A value for {EditorAlias} is required.");
            }

            //if (value is IHtmlString htmlString)
            //{
            //    return htmlString.ToHtmlString();
            //}

            return value.ToString();
        }
    }
}