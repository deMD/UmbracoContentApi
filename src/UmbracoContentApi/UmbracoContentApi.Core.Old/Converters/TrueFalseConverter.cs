using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class TrueFalseConverter : IConverter
    {
        public string EditorAlias => "Umbraco.TrueFalse";

        public object Convert(object value, Dictionary<string, object> options = null)
        {
            return value;
        }
    }
}
