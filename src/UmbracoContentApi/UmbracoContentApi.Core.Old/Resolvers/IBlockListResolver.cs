using System.Collections.Generic;
using Umbraco.Core.Models.Blocks;
using Umbraco.Core.Models.PublishedContent;
using UmbracoContentApi.Core.Models;

namespace UmbracoContentApi.Core.Resolvers
{
    public interface IBlockListResolver
    {
        object ResolveBlockList(BlockListItem blockListItem, Dictionary<string, object> options = null);
    }
}