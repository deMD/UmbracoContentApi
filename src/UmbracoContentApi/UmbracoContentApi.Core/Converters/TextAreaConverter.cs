using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class TextAreaConverter : IConverter
    {
        public string EditorAlias => "Umbraco.TextArea";

        public object Convert(object value, Dictionary<string, object>? options = null)
        {
            return value;
        }
    }
}
