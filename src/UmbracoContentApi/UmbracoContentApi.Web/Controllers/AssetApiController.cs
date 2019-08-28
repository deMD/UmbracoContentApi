using System;
using System.Web.Http;
using System.Web.Http.Description;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Composing;
using Umbraco.Web.WebApi;
using UmbracoContentApi.Core.Models;
using UmbracoContentApi.Core.Resolvers;

namespace UmbracoContentApi.Web.Controllers
{
    [RoutePrefix("api/assets")]
    public class AssetApiController : UmbracoApiController
    {
        private readonly IMediaResolver _mediaResolver;
        private readonly UmbracoHelper _umbracoHelper;

        public AssetApiController(
            IMediaResolver mediaResolver)
        {
            _mediaResolver = mediaResolver;
            _umbracoHelper = Current.UmbracoHelper;
        }

        [Route("{id:guid}")]
        [ResponseType(typeof(ContentModel))]
        public IHttpActionResult Get(Guid id)
        {
            IPublishedContent media = _umbracoHelper.Media(id);
            AssetModel mediaModel = _mediaResolver.ResolveMedia(media);

            return Ok(mediaModel);
        }
    }
}