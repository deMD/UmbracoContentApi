using System;
using Umbraco.Cms.Core.Models.PublishedContent;
using UmbracoContentApi.Core.Resolvers;

namespace UmbracoContentApi.Core.Converters.BlockList
{
    public class DefaultBlockConverter : IBlockConverter
    {
        private readonly Lazy<IContentResolver> _contentResolver;

        public DefaultBlockConverter(Lazy<IContentResolver> contentResolver)
        {
            _contentResolver = contentResolver;
        }

        public string EditorAlias => "DefaultBlockConverter";

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