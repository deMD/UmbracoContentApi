using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class DecimalConverter : IConverter
    {
        public string EditorAlias => "Umbraco.Decimal";

        public object Convert(object value, Dictionary<string, object>? options = null)
        {
            return value;
        }
    }
}
