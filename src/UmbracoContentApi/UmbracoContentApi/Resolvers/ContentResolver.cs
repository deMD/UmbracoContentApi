using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web;
using UmbracoContentApi.Converters;
using UmbracoContentApi.Models;

namespace UmbracoContentApi.Resolvers
{
    public class ContentResolver : IContentResolver
    {
        private readonly IContentService _contentService;

        private readonly IEnumerable<IConverter> _converters;
        private readonly IVariationContextAccessor _variationContextAccessor;

        public ContentResolver(
            IVariationContextAccessor variationContextAccessor,
            IEnumerable<IConverter> converters,
            IContentService contentService)
        {
            _variationContextAccessor = variationContextAccessor;
            _converters = converters;
            _contentService = contentService;
        }

        public ContentModel ResolveContent(IPublishedElement content)
        {
            var contentModel = new ContentModel
            {
                System = new SystemModel
                {
                    Id = content.Key,
                    ContentType = content.ContentType.Alias,
                    Type = content.ContentType.ItemType.ToString()
                }
            };

            if (content is IPublishedContent publishedContent)
            {
                contentModel.System.CreatedAt = publishedContent.CreateDate;
                contentModel.System.EditedAt = publishedContent.UpdateDate;
                contentModel.System.Locale = _variationContextAccessor.VariationContext.Culture;
                contentModel.System.Revision = _contentService.GetVersions(publishedContent.Id).Count();
            }

            var dict = new Dictionary<string, object>();
            foreach (IPublishedProperty property in content.Properties)
            {
                IConverter converter =
                    _converters.FirstOrDefault(x => x.EditorAlias.Equals(property.PropertyType.EditorAlias));
                if (converter != null)
                {
                    object prop = property.Value();

                    if (prop == null)
                    {
                        continue;
                    }

                    prop = converter.Convert(prop);
                    dict.Add(property.Alias, prop);
                }
                else
                {
                    dict.Add(
                        property.Alias,
                        $"No converter implemented for editor: {property.PropertyType.EditorAlias}");
                }
            }

            contentModel.Fields = dict;
            return contentModel;
        }
    }
}