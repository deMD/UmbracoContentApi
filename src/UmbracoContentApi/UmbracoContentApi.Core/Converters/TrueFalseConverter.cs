using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class TrueFalseConverter : IConverter
    {
        public string EditorAlias => "Umbraco.TrueFalse";

        public object Convert(object value, params KeyValuePair<string, object>[] options)
        {
            return value;
        }
    }
}
