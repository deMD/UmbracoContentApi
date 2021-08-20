using System.Linq;
using System.Text;
using HtmlAgilityPack;
using Umbraco.Cms.Core.Macros;
using Umbraco.Cms.Core.Templates;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Macros;
using Umbraco.Extensions;

namespace UmbracoContentApi.Core.Converters.Grid
{
    public class RteConverter : IGridConverter
    {
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;
        private readonly IMacroRenderer _macroRenderer;
        private readonly HtmlLocalLinkParser _linkParser;
        private readonly HtmlUrlParser _urlParser;
        private readonly HtmlImageSourceParser _imageSourceParser;

        public RteConverter(IUmbracoContextAccessor umbracoContextAccessor, IMacroRenderer macroRenderer,
            HtmlLocalLinkParser linkParser, HtmlUrlParser urlParser, HtmlImageSourceParser imageSourceParser)
        {
            _umbracoContextAccessor = umbracoContextAccessor;
            _macroRenderer = macroRenderer;
            _linkParser = linkParser;
            _urlParser = urlParser;
            _imageSourceParser = imageSourceParser;
        }

        public string EditorAlias => "rte";

        public object Convert(object value)
        {
            return Convert(value, false);
        }

        /// <summary>
        /// Copied from <see cref="Umbraco.Cms.Core.PropertyEditors.ValueConverters.RteMacroRenderingValueConverter" />
        /// </summary>
        /// <param name="source"></param>
        /// <param name="preview"></param>
        /// <returns></returns>
        private string Convert(object source, bool preview)
        {
            if (source == null)
            {
                return null;
            }

            var sourceString = source.ToString();

            // ensures string is parsed for {localLink} and URLs and media are resolved correctly
            sourceString = _linkParser.EnsureInternalLinks(sourceString, preview);
            sourceString = _urlParser.EnsureUrls(sourceString);
            sourceString = _imageSourceParser.EnsureImageSources(sourceString);

            // ensure string is parsed for macros and macros are executed correctly
            sourceString = RenderRteMacros(sourceString, preview);

            // find and remove the rel attributes used in the Umbraco UI from img tags
            var doc = new HtmlDocument();
            doc.LoadHtml(sourceString);

            if (doc.ParseErrors.Any() == false && doc.DocumentNode != null)
            {
                // Find all images with rel attribute
                var imgNodes = doc.DocumentNode.SelectNodes("//img[@rel]");

                var modified = false;
                if (imgNodes != null)
                {
                    foreach (var img in imgNodes)
                    {
                        var nodeId = img.GetAttributeValue("rel", string.Empty);
                        if (int.TryParse(nodeId, out _))
                        {
                            img.Attributes.Remove("rel");
                            modified = true;
                        }
                    }
                }

                // Find all a and img tags with a data-udi attribute
                var dataUdiNodes = doc.DocumentNode.SelectNodes("(//a|//img)[@data-udi]");
                if (dataUdiNodes != null)
                {
                    foreach (var node in dataUdiNodes)
                    {
                        node.Attributes.Remove("data-udi");
                        modified = true;
                    }
                }

                if (modified)
                {
                    return doc.DocumentNode.OuterHtml;
                }
            }

            return sourceString;
        }

        /// <summary>
        /// Copied from <see cref="Umbraco.Cms.Core.PropertyEditors.ValueConverters.RteMacroRenderingValueConverter" />
        /// </summary>
        /// <param name="source"></param>
        /// <param name="preview"></param>
        /// <returns></returns>
        private string RenderRteMacros(string source, bool preview)
        {
            var umbracoContext = _umbracoContextAccessor.GetRequiredUmbracoContext();
            using (umbracoContext.ForcedPreview(preview)) // force for macro rendering
            {
                var sb = new StringBuilder();

                MacroTagParser.ParseMacros(
                    source,
                    //callback for when text block is found
                    textBlock => sb.Append(textBlock),
                    //callback for when macro syntax is found
                    (macroAlias, macroAttributes) => sb.Append(_macroRenderer.RenderAsync(
                        macroAlias,
                        umbracoContext.PublishedRequest?.PublishedContent,
                        //needs to be explicitly casted to Dictionary<string, object>
                        macroAttributes.ConvertTo(x => (string)x, x => x)).GetAwaiter().GetResult().Text));

                return sb.ToString();
            }
        }
    }
}
