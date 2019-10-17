using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class TagsConverter : IConverter
    {
        public string EditorAlias => "Umbraco.Tags";

        public object Convert(object value, params KeyValuePair<string, object>[] options)
        {
            return value;
        }
    }
}
