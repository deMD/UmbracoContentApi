using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class TextBoxConverter : IConverter
    {
        public string EditorAlias => "Umbraco.TextBox";

        public object Convert(object value, params KeyValuePair<string, object>[] options)
        {
            return value;
        }
    }
}
