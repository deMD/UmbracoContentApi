using Umbraco.Core.Models.PublishedContent;
using UmbracoContentApi.Models;

namespace UmbracoContentApi.Resolvers
{
    public interface IContentResolver
    {
        ContentModel ResolveContent(IPublishedElement content, string culture = null);
    }
}