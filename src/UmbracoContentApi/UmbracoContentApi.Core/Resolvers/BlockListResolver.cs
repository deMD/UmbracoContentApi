using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.Blocks;
using UmbracoContentApi.Core.Builder;
using UmbracoContentApi.Core.Converters.BlockList;

namespace UmbracoContentApi.Core.Resolvers
{
    public class BlockListResolver : IBlockListResolver
    {
        private readonly BlockConverterCollection _blockConverters;

        public BlockListResolver(BlockConverterCollection blockConverters)
        {
            _blockConverters = blockConverters;
        }

        public object ResolveBlockList(BlockListItem blockListItem, Dictionary<string, object>? options = null)
        {
            var converter =
                _blockConverters.FirstOrDefault(
                    x => x.EditorAlias.Equals(blockListItem.Content.ContentType.Alias)) ??
                _blockConverters.FirstOrDefault(x => x.EditorAlias.Equals(nameof(DefaultBlockConverter)));

            return converter?.Convert(blockListItem.Content) ??
                   $"No converter implemented for: {blockListItem.Content.ContentType.Alias}";
        }
    }
}