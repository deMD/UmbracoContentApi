using Umbraco.Cms.Core.Composing;
using UmbracoContentApi.Core.Converters.Grid;

namespace UmbracoContentApi.Core.Builder
{
    public class GridConverterCollectionBuilder : OrderedCollectionBuilderBase<GridConverterCollectionBuilder,
        GridConverterCollection, IGridConverter>
    {
        protected override GridConverterCollectionBuilder This => this;
    }
}
