using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Composing;
using Umbraco.Web.WebApi;
using UmbracoContentApi.Converters;
using UmbracoContentApi.Models;

namespace UmbracoContentApi.Controllers
{
    public class EntryApiController : UmbracoApiController
    {
        private readonly IEnumerable<IConverter> _converters;
        private readonly UmbracoHelper _umbracoHelper;
        private readonly IVariationContextAccessor _variationContextAccessor;

        public EntryApiController(
            IVariationContextAccessor variationContextAccessor,
            IEnumerable<IConverter> converters)
        {
            _variationContextAccessor = variationContextAccessor;
            _converters = converters;
            _umbracoHelper = Current.UmbracoHelper;
        }

        public IHttpActionResult Get(Guid id, string culture = null)
        {
            IPublishedContent content = _umbracoHelper.Content(id);

            var entry = new EntryModel
            {
                System = new SystemModel
                {
                    Id = content.Key,
                    ContentType = content.ContentType.Alias,
                    CreatedAt = content.CreateDate,
                    EditedAt = content.UpdateDate,
                    Locale = content.Cultures.FirstOrDefault(x => x.Key == culture).Value?.Culture ??
                             _variationContextAccessor.VariationContext.Culture,
                    Type = "Entry",
                    Revision = Services.ContentService.GetVersions(content.Id).Count()
                }
            };

            var dict = new Dictionary<string, object>();
            foreach (IPublishedProperty property in content.Properties)
            {
                IConverter converter =
                    _converters.FirstOrDefault(x => x.EditorAlias.Equals(property.PropertyType.EditorAlias));
                if (converter != null)
                {
                    object prop = property.Value(culture);
                    prop = converter.Convert(prop);
                    dict.Add(property.Alias, prop);
                }
                else
                {
                    dict.Add(property.Alias, $"No converter implemented for editor: {property.PropertyType.EditorAlias}");
                }
            }

            entry.Fields = dict;

            return Json(
                entry,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }
    }
}