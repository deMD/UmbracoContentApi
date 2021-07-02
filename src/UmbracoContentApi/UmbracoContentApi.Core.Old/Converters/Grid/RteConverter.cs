using Umbraco.Web;
using Umbraco.Web.Templates;

namespace UmbracoContentApi.Core.Converters.Grid
{
    public class RteConverter : IGridConverter
    {
        private readonly IUmbracoContextFactory _umbracoContextFactory;
        private readonly HtmlLocalLinkParser _localLinkParser;

        public RteConverter(IUmbracoContextFactory umbracoContextFactory, HtmlLocalLinkParser localLinkParser)
        {
            _umbracoContextFactory = umbracoContextFactory;
            _localLinkParser = localLinkParser;
        }

        public string EditorAlias => "rte";

        public object Convert(object value)
        {
            using (var cRef = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var parsedHtml = _localLinkParser.EnsureInternalLinks(value.ToString(), false);
                return parsedHtml;
            }
        }
    }
}
