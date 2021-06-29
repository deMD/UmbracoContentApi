using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;
using UmbracoContentApi.Core.Models;

namespace UmbracoContentApi.Core.Resolvers
{
    public interface IContentResolver
    {
        ContentModel ResolveContent(IPublishedElement content, Dictionary<string, object> options = null);
    }
}