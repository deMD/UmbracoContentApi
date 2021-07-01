using System;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core;
using Umbraco.Cms.Web.Common.Controllers;
using UmbracoContentApi.Core.Resolvers;

namespace UmbracoContentApi.Web.Controllers
{
    [Route("api/assets")]
    public class AssetApiController : UmbracoApiController
    {
        private readonly IMediaResolver _mediaResolver;
        private readonly IPublishedContentQuery _publishedContent;

        public AssetApiController(
            IMediaResolver mediaResolver, IPublishedContentQuery publishedContent)
        {
            _mediaResolver = mediaResolver;
            _publishedContent = publishedContent;
        }

        [Route("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var media = _publishedContent.Media(id);
            var mediaModel = _mediaResolver.ResolveMedia(media);

            return Ok(mediaModel);
        }
    }
}