using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class TextAreaConverter : IConverter
    {
        public string EditorAlias => "Umbraco.TextArea";

        public object Convert(object value, params KeyValuePair<string, object>[] options)
        {
            return value;
        }
    }
}
