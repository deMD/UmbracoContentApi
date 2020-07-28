using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NPoco;
using Umbraco.Core.Logging;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web;
using UmbracoContentApi.Core.Converters;
using UmbracoContentApi.Core.Models;

namespace UmbracoContentApi.Core.Resolvers
{
    public class ContentResolver : IContentResolver
    {
        private readonly IContentService _contentService;

        private readonly IEnumerable<IConverter> _converters;
        private readonly IVariationContextAccessor _variationContextAccessor;
        private readonly ILogger _logger;

        public ContentResolver(
            IVariationContextAccessor variationContextAccessor,
            IEnumerable<IConverter> converters,
            IContentService contentService,
            ILogger logger)
        {
            _variationContextAccessor = variationContextAccessor;
            _converters = converters;
            _contentService = contentService;
            _logger = logger;
        }

        public ContentModel ResolveContent(IPublishedElement content, Dictionary<string, object> options = null)
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
                        bool.TryParse(options["addUrl"].ToString(), out bool addUrl) &&
                        addUrl)
                    {
                        contentModel.System.Url = publishedContent.Url(mode: UrlMode.Absolute);
                    }
                }

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

                      
                        prop = converter.Convert(prop, options?.ToDictionary(x => x.Key, x => x.Value));
                      
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
            catch (Exception e)
            {
                _logger.Error<ContentResolver>(e);
                throw;
            }
        }
    }
}