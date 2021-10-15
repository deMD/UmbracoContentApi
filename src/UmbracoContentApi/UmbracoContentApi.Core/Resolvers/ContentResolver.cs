using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;
using UmbracoContentApi.Core.Builder;
using UmbracoContentApi.Core.Models;

namespace UmbracoContentApi.Core.Resolvers
{
    public class ContentResolver : IContentResolver
    {
        private readonly ConverterCollection _converters;
        private readonly ILogger<ContentResolver> _logger;
        private readonly IPublishedValueFallback _publishedValueFallback;
        private readonly IVariationContextAccessor _variationContextAccessor;

        public ContentResolver(
            IVariationContextAccessor variationContextAccessor,
            ConverterCollection converters,
            ILogger<ContentResolver> logger,
            IPublishedValueFallback publishedValueFallback)
        {
            _variationContextAccessor = variationContextAccessor;
            _converters = converters;
            _logger = logger;
            _publishedValueFallback = publishedValueFallback;
        }

        public ContentModel ResolveContent(IPublishedElement content, Dictionary<string, object>? options = null)
        {
            try
            {
                if (content == null)
                {
                    throw new ArgumentNullException(nameof(content));
                }

                var contentModel = new ContentModel
                {
                    System = new SystemModel
                    {
                        Id = content.Key,
                        ContentType = content.ContentType.Alias,
                        Type = content.ContentType.ItemType.ToString()
                    }
                };

                var dict = new Dictionary<string, object>();


                if (content is IPublishedContent publishedContent)
                {
                    contentModel.System.CreatedAt = publishedContent.CreateDate;
                    contentModel.System.EditedAt = publishedContent.UpdateDate;
                    contentModel.System.Locale = _variationContextAccessor.VariationContext.Culture;
                    contentModel.System.Name = publishedContent.Name;
                    contentModel.System.UrlSegment = publishedContent.UrlSegment;

                    if (options != null &&
                        options.ContainsKey("addUrl") &&
                        bool.TryParse(options["addUrl"].ToString(), out var addUrl) &&
                        addUrl)
                    {
                        contentModel.System.Url = publishedContent.Url(mode: UrlMode.Absolute);
                    }
                }

                foreach (var property in content.Properties)
                {
                    var converter =
                        _converters.FirstOrDefault(x => x.EditorAlias.Equals(property.PropertyType.EditorAlias));
                    if (converter != null)
                    {
                        var prop = property.Value(_publishedValueFallback);

                        if (prop == null)
                        {
                            continue;
                        }


                        prop = converter.Convert(prop, options?.ToDictionary(x => x.Key, x => x.Value));

                        if (prop != null)
                        {
                            dict.Add(property.Alias, prop);
                        }
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
            catch (Exception e)
            {
                _logger.LogError(e, "An exceptional exception happened, see the inner exception for details");
                throw;
            }
        }
    }
}