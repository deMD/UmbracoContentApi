using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.Blocks;
using UmbracoContentApi.Core.Converters.BlockList;

namespace UmbracoContentApi.Core.Resolvers
{
    public class BlockListResolver : IBlockListResolver
    {
        private readonly IEnumerable<IBlockConverter> _blockConverters;

        public BlockListResolver(IEnumerable<IBlockConverter> blockConverters)
        {
            _blockConverters = blockConverters;
        }

        public object ResolveBlockList(BlockListItem blockListItem, Dictionary<string, object> options = null)
        {
            var converter =
                _blockConverters.FirstOrDefault(
                    x => x.EditorAlias.Equals(blockListItem.Content.ContentType.Alias));
            return converter?.Convert(blockListItem.Content) ??
                   $"No converter implemented for: {blockListItem.Content.ContentType.Alias}";
        }
    }
}