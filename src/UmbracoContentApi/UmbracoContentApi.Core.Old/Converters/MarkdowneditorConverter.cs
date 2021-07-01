using System.Collections.Generic;
using System.Web;

namespace UmbracoContentApi.Core.Converters
{
    public class MarkdowneditorConverter : IConverter
    {
        /// <inheritdoc />
        public string EditorAlias => "Umbraco.MarkdownEditor";

        /// <inheritdoc />
        public object Convert(object value, Dictionary<string, object> options = null)
        {
            if (value is IHtmlString htmlString)
            {
                return htmlString.ToHtmlString();
            }

            return default;
        }
    }
}
