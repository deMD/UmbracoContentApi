using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class MarkdowneditorConverter : IConverter
    {
        public string EditorAlias => "Umbraco.MarkdownEditor";

        public object Convert(object value, params KeyValuePair<string, object>[] options)
        {
            return value;
        }
    }
}
