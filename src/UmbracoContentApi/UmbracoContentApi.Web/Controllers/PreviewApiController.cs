using System;
using System.Web.Http;
using System.Web.Http.Description;
using Umbraco.Web.WebApi;
using UmbracoContentApi.Core.Models;
using UmbracoContentApi.Core.Resolvers;

namespace UmbracoContentApi.Web.Controllers
{
    [RoutePrefix("api/preview")]
    public class PreviewApiController : UmbracoApiController
    {
        private readonly Lazy<IContentResolver> _contentResolver;

        public PreviewApiController(Lazy<IContentResolver> contentResolver)
        {
            _contentResolver = contentResolver;
        }

        [Route("{id:guid}")]
        [ResponseType(typeof(ContentModel))]
        public IHttpActionResult Get(Guid id)
        {
            var preview = UmbracoContext.Content.GetById(true, id);
            
            ContentModel contentModel = _contentResolver.Value.ResolveContent(preview);

            return Ok(contentModel);
        }
    }
}