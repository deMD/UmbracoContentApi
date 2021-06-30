using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class MarkdowneditorConverter : IConverter
    {
        /// <inheritdoc />
        public string EditorAlias => "Umbraco.MarkdownEditor";

        /// <inheritdoc />
        public object Convert(object value, Dictionary<string, object> options = null)
        {
            return value.ToString();
        }
    }
}
