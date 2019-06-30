using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using HtmlAgilityPack;

namespace UmbracoContentApi.Converters
{
    public class HtmlStringConverter : IConverter<IHtmlString>
    {
        public object Convert(IHtmlString value)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(value.ToHtmlString());

            return value;
        }
    }
}