using System.Collections.Generic;
using Umbraco.Cms.Core.Models.Blocks;

namespace UmbracoContentApi.Core.Resolvers
{
    public interface IBlockListResolver
    {
        object ResolveBlockList(BlockListItem blockListItem, Dictionary<string, object>? options = null);
    }
}