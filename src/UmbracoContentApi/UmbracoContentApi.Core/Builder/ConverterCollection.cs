using System.Collections.Generic;
using Umbraco.Cms.Core.Composing;
using UmbracoContentApi.Core.Converters;

namespace UmbracoContentApi.Core.Builder
{
    public class ConverterCollection : BuilderCollectionBase<IConverter>
    {
        public ConverterCollection(IEnumerable<IConverter> items)
            : base(items)
        { }
    }
}