using Umbraco.Cms.Core.DependencyInjection;
using UmbracoContentApi.Core.Builder;

namespace UmbracoContentApi.Core
{
    public static class ConverterCompositionExtensions
    {
        public static ConverterCollectionBuilder Converters(this IUmbracoBuilder builder)
        {
            return builder.WithCollectionBuilder<ConverterCollectionBuilder>();
        }
    }
}