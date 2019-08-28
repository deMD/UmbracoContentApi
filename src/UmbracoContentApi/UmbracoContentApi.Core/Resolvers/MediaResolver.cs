using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web;
using UmbracoContentApi.Core.Converters;
using UmbracoContentApi.Core.Enums;
using UmbracoContentApi.Core.Models;

namespace UmbracoContentApi.Core.Resolvers
{
    public class MediaResolver : IMediaResolver
    {
        private readonly IContentService _contentService;
        private readonly IEnumerable<IConverter> _converters;
        private readonly IVariationContextAccessor _variationContextAccessor;

        public MediaResolver(
            IVariationContextAccessor variationContextAccessor,
            IContentService contentService,
            IEnumerable<IConverter> converters)
        {
            _variationContextAccessor = variationContextAccessor;
            _contentService = contentService;
            _converters = converters;
        }

        public AssetModel ResolveMedia(IPublishedContent media)
        {
            var mediaModel = new AssetModel
            {
                System = new SystemModel
                {
                    Id = media.Key,
                    ContentType = media.ContentType.Alias,
                    CreatedAt = media.CreateDate,
                    EditedAt = media.UpdateDate,
                    Locale = _variationContextAccessor.VariationContext.Culture,
                    Type = ContentType.Media.ToString(),
                    Revision = _contentService.GetVersions(media.Id).Count()
                }
            };

            var dict = new Dictionary<string, object>
            {
                {"Name", media.Name}
            };

            foreach (IPublishedProperty property in media.Properties)
            {
                IConverter converter =
                    _converters.FirstOrDefault(x => x.EditorAlias.Equals(property.PropertyType.EditorAlias));
                if (converter != null)
                {
                    object prop = property.Value();
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

            mediaModel.Fields = dict;

            return mediaModel;
        }
    }
}