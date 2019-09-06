using System.Web;

namespace UmbracoContentApi.Core.Converters
{
    public class TinyMceConverter : IConverter
    {
        public string EditorAlias => "Umbraco.TinyMCE";

        public object Convert(object value)
        {
            if (value is IHtmlString htmlString)
            {
                return htmlString.ToHtmlString();
            }

            return default;
        }
    }
}