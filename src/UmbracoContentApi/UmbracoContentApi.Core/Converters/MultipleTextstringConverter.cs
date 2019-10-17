using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class MultipleTextstringConverter : IConverter
    {
        public string EditorAlias => "Umbraco.MultipleTextstring";

        public object Convert(object value, params KeyValuePair<string, object>[] options)
        {
            return value;
        }
    }
}
