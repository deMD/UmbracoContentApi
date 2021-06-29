using Umbraco.Cms.Core.DependencyInjection;
using UmbracoContentApi.Core.Builder;

namespace UmbracoContentApi.Core
{
    public static class BlockConverterCompositionExtensions
    {
        public static BlockConverterCollectionBuilder BlockConverters(this IUmbracoBuilder builder)
        {
            return builder.WithCollectionBuilder<BlockConverterCollectionBuilder>();
        }
    }
}
