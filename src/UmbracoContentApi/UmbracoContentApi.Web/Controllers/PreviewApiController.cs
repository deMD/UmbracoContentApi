using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common.Controllers;
using UmbracoContentApi.Core.Resolvers;

namespace UmbracoContentApi.Web.Controllers
{
    [Route("api/preview")]
    public class PreviewApiController : UmbracoApiController
    {
        private readonly Lazy<IContentResolver> _contentResolver;
        private readonly IContentService _contentService;
        private readonly IPublishedSnapshotService _publishedSnapshotService;
        private readonly IUserService _userService;

        public PreviewApiController(
            Lazy<IContentResolver> contentResolver,
            IPublishedSnapshotService publishedSnapshotService,
            IUserService userService,
            IContentService contentService)
        {
            _contentResolver = contentResolver;
            _publishedSnapshotService = publishedSnapshotService;
            _userService = userService;
            _contentService = contentService;
        }

        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            //IPublishedContent content = _publishedSnapshotService.CreatePublishedSnapshot(
            //        _publishedSnapshotService.EnterPreview(
            //            _userService.GetUserById(-1),
            //            _contentService.GetById(id).Id))
            //    .Content.GetById(id);

            //ContentModel contentModel = _contentResolver.Value.ResolveContent(content);
            //return Ok(contentModel);
            return StatusCode((int) HttpStatusCode.Gone);
        }
    }
}