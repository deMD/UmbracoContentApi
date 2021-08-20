using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Composing;
using UmbracoContentApi.Core.Converters.BlockList;

namespace UmbracoContentApi.Core.Builder
{
    public class BlockConverterCollection : BuilderCollectionBase<IBlockConverter>
    {
        public BlockConverterCollection(Func<IEnumerable<IBlockConverter>> items) : base(items)
        { }
    }
}
