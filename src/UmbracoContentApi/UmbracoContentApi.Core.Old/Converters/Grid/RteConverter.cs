using Umbraco.Web;
using Umbraco.Web.Templates;

namespace UmbracoContentApi.Core.Converters.Grid
{
    public class RteConverter : IGridConverter
    {
        private readonly IUmbracoContextFactory _umbracoContextFactory;

        public RteConverter(IUmbracoContextFactory umbracoContextFactory)
        {
            _umbracoContextFactory = umbracoContextFactory;
        }

        public string EditorAlias => "rte";

        public object Convert(object value)
        {
            using (var cRef = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var parsedHtml = TemplateUtilities.ParseInternalLinks(
                    value.ToString(),
                    cRef.UmbracoContext.UrlProvider);
                return parsedHtml;
            }
        }
    }
}
