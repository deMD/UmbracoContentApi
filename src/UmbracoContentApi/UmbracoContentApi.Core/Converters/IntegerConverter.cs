using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class IntegerConverter : IConverter
    {
        public string EditorAlias => "Umbraco.Integer";

        public object Convert(object value, params KeyValuePair<string, object>[] options)
        {
            return value;
        }
    }
}
