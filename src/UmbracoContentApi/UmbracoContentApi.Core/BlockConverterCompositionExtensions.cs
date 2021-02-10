using Umbraco.Core.Composing;
using UmbracoContentApi.Core.Builder;

namespace UmbracoContentApi.Core
{
    public static class BlockConverterCompositionExtensions
    {
        public static BlockConverterCollectionBuilder BlockConverters(this Composition composition)
        {
            return composition.WithCollectionBuilder<BlockConverterCollectionBuilder>();
        }
    }
}
