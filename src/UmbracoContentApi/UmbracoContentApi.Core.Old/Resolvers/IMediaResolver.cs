using Umbraco.Core.Models.PublishedContent;
using UmbracoContentApi.Core.Models;

namespace UmbracoContentApi.Core.Resolvers
{
    public interface IMediaResolver
    {
        AssetModel ResolveMedia(IPublishedContent media);
    }
}