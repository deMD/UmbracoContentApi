using System;
using Newtonsoft.Json;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Models.PublishedContent;
using UmbracoContentApi.Core;
using UmbracoContentApi.Core.Converters.BlockList;
using UmbracoContentApi.Core.Resolvers;

namespace UmbracoContentApi.Web
{
    public class BlocklistComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.BlockConverters().Append<SampleBlockConverter>();
        }
    }

    // ReSharper disable once ClassNeverInstantiated.Global
    public class SampleBlockConverter : IBlockConverter
    {
        private readonly Lazy<IContentResolver> _contentResolver;

        public SampleBlockConverter(Lazy<IContentResolver> contentResolver)
        {
            _contentResolver = contentResolver;
        }
        
        public string EditorAlias => "sampleBlock";
        public object Convert(object value)
        {
            if (value is not IPublishedElement element)
            {
                throw new ArgumentNullException(nameof(value), $"A value for {EditorAlias} is required.");
            }

            return _contentResolver.Value.ResolveContent(element);
        }
    }
}