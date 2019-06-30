using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Umbraco.Web;
using Umbraco.Web.Composing;
using Umbraco.Web.WebApi;
using UmbracoContentApi.Converters;
using UmbracoContentApi.Models;

namespace UmbracoContentApi.Controllers
{
    public class EntryApiController : UmbracoApiController
    {
        private readonly UmbracoHelper _umbracoHelper;

        public EntryApiController()
        {
            _umbracoHelper = Current.UmbracoHelper;
        }

        public IHttpActionResult Get(int id, string culture = null)
        {
            var content = _umbracoHelper.Content(id);

            var entry = new EntryModel
            {
                System = new SystemModel
                {
                    Id = content.Id,
                    ContentType = content.ContentType.Alias,
                    CreatedAt = content.CreateDate,
                    EditedAt = content.UpdateDate,
                    Locale = content.GetCulture(culture).Culture,
                    Type = "Entry",
                    Revision = Services.ContentService.GetVersions(id).Count()
                }
            };

            var dict = new Dictionary<string, object>();
            foreach (var property in content.Properties)
            {
                var prop = property.Value(culture);
                if (prop is IHtmlString html)
                {
                    var converter = new HtmlStringConverter();
                    prop = converter.Convert(html);
                }

                dict.Add(property.Alias, prop);
            }

            entry.Fields = dict;

            return Json(entry, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}