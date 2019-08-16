using System;
using System.Web.Http;
using System.Web.Http.Description;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Composing;
using Umbraco.Web.WebApi;
using UmbracoContentApi.Models;
using UmbracoContentApi.Resolvers;

namespace UmbracoContentApi.Controllers
{
    [RoutePrefix("api/content")]
    public class ContentApiController : UmbracoApiController
    {
        private readonly Lazy<IContentResolver> _contentResolver;
        private readonly UmbracoHelper _umbracoHelper;

        public ContentApiController(Lazy<IContentResolver> contentResolver)
        {
            _contentResolver = contentResolver;
            _umbracoHelper = Current.UmbracoHelper;
        }

        [Route("{id:guid}")]
        [ResponseType(typeof(ContentModel))]
        public IHttpActionResult Get(Guid id, string culture = null)
        {
            IPublishedContent content = _umbracoHelper.Content(id);

            ContentModel contentModel = _contentResolver.Value.ResolveContent(content, culture);

            return Ok(contentModel);
        }
    }
}