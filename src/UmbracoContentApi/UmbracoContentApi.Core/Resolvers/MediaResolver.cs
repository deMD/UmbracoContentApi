using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web;
using Umbraco.Extensions;
using UmbracoContentApi.Core.Converters;
using UmbracoContentApi.Core.Enums;
using UmbracoContentApi.Core.Models;

namespace UmbracoContentApi.Core.Resolvers
{
    public class MediaResolver : IMediaResolver
    {
        private readonly IContentService _contentService;
        private readonly IEnumerable<IConverter> _converters;
        private readonly ILogger<MediaResolver> _logger;
        private readonly IPublishedValueFallback _publishedValueFallback;
        private readonly IVariationContextAccessor _variationContextAccessor;

        public MediaResolver(
            IVariationContextAccessor variationContextAccessor,
            IContentService contentService,
            IEnumerable<IConverter> converters,
            ILogger<MediaResolver> logger,
            IPublishedValueFallback publishedValueFallback)
        {
            _variationContextAccessor = variationContextAccessor;
            _contentService = contentService;
            _converters = converters;
            _logger = logger;
            _publishedValueFallback = publishedValueFallback;
        }

        public AssetModel ResolveMedia(IPublishedContent media)
        {
            try
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
                        Type = ContentType.Media.ToString()
                    }
                };

                var dict = new Dictionary<string, object>
                {
                    { "Name", media.Name }
                };

                foreach (IPublishedProperty property in media.Properties)
                {
                    IConverter converter =
                        _converters.FirstOrDefault(x => x.EditorAlias.Equals(property.PropertyType.EditorAlias));
                    if (converter != null)
                    {
                        object prop = property.Value(_publishedValueFallback);
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
            catch (Exception e)
            {
                _logger.LogError(e, "Something went wrong, see the inner exception for details.");
                throw;
            }
        }
    }
}