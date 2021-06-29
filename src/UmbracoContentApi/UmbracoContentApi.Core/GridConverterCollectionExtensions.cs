using Umbraco.Cms.Core.DependencyInjection;
using UmbracoContentApi.Core.Builder;

namespace UmbracoContentApi.Core
{
    public static class GridConverterCompositionExtensions
    {
        public static GridConverterCollectionBuilder GridConverters(this IUmbracoBuilder builder)
        {
            return builder.WithCollectionBuilder<GridConverterCollectionBuilder>();
        }
    }
}
