using System.Collections.Generic;
using Umbraco.Core.Composing;
using UmbracoContentApi.Core.Converters.Grid;

namespace UmbracoContentApi.Core.Builder
{
    public class GridConverterCollection : BuilderCollectionBase<IGridConverter>
    {
        public GridConverterCollection(IEnumerable<IGridConverter> items) : base(items)
        { }
    }
}
