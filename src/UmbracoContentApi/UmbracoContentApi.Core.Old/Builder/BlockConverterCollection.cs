using System.Collections.Generic;
using Umbraco.Core.Composing;
using UmbracoContentApi.Core.Converters.BlockList;

namespace UmbracoContentApi.Core.Builder
{
    public class BlockConverterCollection : BuilderCollectionBase<IBlockConverter>
    {
        public BlockConverterCollection(IEnumerable<IBlockConverter> items) : base(items)
        { }
    }
}
