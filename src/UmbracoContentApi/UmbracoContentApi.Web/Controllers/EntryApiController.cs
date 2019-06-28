using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Umbraco.Web;
using Umbraco.Web.Composing;
using Umbraco.Web.WebApi;

namespace UmbracoContentApi.Web.Controllers
{
    public class EntryApiController : UmbracoApiController
    {
        private readonly UmbracoHelper _umbracoHelper;

        public EntryApiController()
        {
            _umbracoHelper = Current.UmbracoHelper;
        }

        public IHttpActionResult Get(int id)
        {
            var content = _umbracoHelper.Content(id);
            
            return Json(content, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}