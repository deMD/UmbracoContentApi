using System;
using System.Web.Http;
using System.Web.Http.Description;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Composing;
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
        private readonly UmbracoHelper _umbracoHelper;

        public ContentApiController(Lazy<IContentResolver> contentResolver, IVariationContextAccessor variationContextAccessor)
        {
            _contentResolver = contentResolver;
            _variationContextAccessor = variationContextAccessor;
            _umbracoHelper = Current.UmbracoHelper;
        }

        [Route("{id:guid}")]
        [ResponseType(typeof(ContentModel))]
        public IHttpActionResult Get(Guid id)
        { 
            IPublishedContent content = _umbracoHelper.Content(id);
            var model = _contentResolver.Value.ResolveContent(content);
            return Ok(model);
        }
    }
}