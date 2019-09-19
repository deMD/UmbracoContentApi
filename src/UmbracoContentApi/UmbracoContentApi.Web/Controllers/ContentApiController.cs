using System;
using System.Web.Http;
using System.Web.Http.Description;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.WebApi;
using UmbracoContentApi.Core.Resolvers;
using UmbracoContentApi.Core.Models;

namespace UmbracoContentApi.Web.Controllers
{
    [RoutePrefix("api/content")]
    public class ContentApiController : UmbracoApiController
    {
        private readonly Lazy<IContentResolver> _contentResolver;
        private readonly IVariationContextAccessor _variationContextAccessor;

        public ContentApiController(Lazy<IContentResolver> contentResolver, IVariationContextAccessor variationContextAccessor)
        {
            _contentResolver = contentResolver;
            _variationContextAccessor = variationContextAccessor;
        }

        [Route("{id:guid}")]
        [ResponseType(typeof(ContentModel))]
        public IHttpActionResult Get(Guid id)
        { 
            IPublishedContent content = Umbraco.Content(id);
            var model = _contentResolver.Value.ResolveContent(content);
            return Ok(model);
        }
    }
}