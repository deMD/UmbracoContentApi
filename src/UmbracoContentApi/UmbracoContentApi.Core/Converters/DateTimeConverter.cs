using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class DateTimeConverter : IConverter
    {
        public string EditorAlias => "Umbraco.DateTime";

        public object Convert(object value, params KeyValuePair<string, object>[] options)
        {
            return value;
        }
    }
}
