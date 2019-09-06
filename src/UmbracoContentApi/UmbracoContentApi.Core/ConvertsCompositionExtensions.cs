using Umbraco.Core.Composing;

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