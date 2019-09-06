using Umbraco.Core.Composing;
using UmbracoContentApi.Core.Converters;

namespace UmbracoContentApi.Core
{
    public class ConverterCollectionBuilder : OrderedCollectionBuilderBase<ConverterCollectionBuilder,
        ConverterCollection, IConverter>
    {
        protected override ConverterCollectionBuilder This => this;
    }
}