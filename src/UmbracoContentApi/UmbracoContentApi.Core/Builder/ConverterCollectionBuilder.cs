using Umbraco.Cms.Core.Composing;
using UmbracoContentApi.Core.Converters;

namespace UmbracoContentApi.Core.Builder
{
    public class ConverterCollectionBuilder : OrderedCollectionBuilderBase<ConverterCollectionBuilder,
        ConverterCollection, IConverter>
    {
        protected override ConverterCollectionBuilder This => this;
    }
}