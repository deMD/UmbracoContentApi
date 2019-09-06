using Umbraco.Core.Composing;
using UmbracoContentApi.Core.Builder;

namespace UmbracoContentApi.Core
{
    public static class ConvertsCompositionExtensions
    {
        public static ConverterCollectionBuilder Converters(this Composition composition)
        {
            return composition.WithCollectionBuilder<ConverterCollectionBuilder>();
        }
    }
}