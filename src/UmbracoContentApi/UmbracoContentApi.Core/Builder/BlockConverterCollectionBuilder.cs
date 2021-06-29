using Umbraco.Cms.Core.Composing;
using UmbracoContentApi.Core.Converters.BlockList;

namespace UmbracoContentApi.Core.Builder
{
    public class BlockConverterCollectionBuilder : OrderedCollectionBuilderBase<BlockConverterCollectionBuilder,
        BlockConverterCollection, IBlockConverter>
    {
        protected override BlockConverterCollectionBuilder This => this;
    }
}
