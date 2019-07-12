using System.Web;
using HtmlAgilityPack;

namespace UmbracoContentApi.Converters
{
    internal class TinyMceConverter : IConverter
    {
        public string EditorAlias => "Umbraco.TinyMCE";

        public object Convert(object value)
        {
            if (value is IHtmlString htmlString)
            {
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(htmlString.ToHtmlString());

                return value;
            }

            return default;
        }
    }
}