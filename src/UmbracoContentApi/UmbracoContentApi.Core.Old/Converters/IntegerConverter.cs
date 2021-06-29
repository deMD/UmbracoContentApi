using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class IntegerConverter : IConverter
    {
        public string EditorAlias => "Umbraco.Integer";

        public object Convert(object value, Dictionary<string, object> options = null)
        {
            return value;
        }
    }
}
