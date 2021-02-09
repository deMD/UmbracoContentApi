using Umbraco.Core.Composing;
using UmbracoContentApi.Core.Builder;

namespace UmbracoContentApi.Core
{
    public static class GridConverterCompositionExtensions
    {
        public static GridConverterCollectionBuilder GridConverters(this Composition composition)
        {
            return composition.WithCollectionBuilder<GridConverterCollectionBuilder>();
        }
    }
}
