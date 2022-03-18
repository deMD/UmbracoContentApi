using Umbraco.Web;
using Umbraco.Web.Templates;

namespace UmbracoContentApi.Core.Converters.Grid
{
    public class RteConverter : IGridConverter
    {
        private readonly IUmbracoContextFactory _umbracoContextFactory;
        private readonly HtmlLocalLinkParser _localLinkParser;
        private readonly HtmlImageSourceParser _localImageParser;


        public RteConverter(IUmbracoContextFactory umbracoContextFactory, HtmlLocalLinkParser localLinkParser, HtmlImageSourceParser localImageParser)
        {
            _umbracoContextFactory = umbracoContextFactory;
            _localLinkParser = localLinkParser;
            _localImageParser = localImageParser;
        }

        public string EditorAlias => "rte";

        public object Convert(object value)
        {
            using (var cRef = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var parsedHtml = _localLinkParser.EnsureInternalLinks(value.ToString(), false);
                parsedHtml = _localImageParser.EnsureImageSources(parsedHtml);
                return parsedHtml;
            }
        }
    }
}
