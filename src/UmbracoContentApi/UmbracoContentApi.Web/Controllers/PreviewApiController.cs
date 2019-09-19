using System;
using System.Web.Http;
using System.Web.Http.Description;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web.PublishedCache;
using Umbraco.Web.WebApi;
using UmbracoContentApi.Core.Models;
using UmbracoContentApi.Core.Resolvers;

namespace UmbracoContentApi.Web.Controllers
{
    [RoutePrefix("api/preview")]
    public class PreviewApiController : UmbracoApiController
    {
        private readonly Lazy<IContentResolver> _contentResolver;
        private readonly IPublishedSnapshotService _publishedSnapshotService;
        private readonly IUserService _userService;
        private readonly IContentService _contentService;

        public PreviewApiController(Lazy<IContentResolver> contentResolver, IPublishedSnapshotService publishedSnapshotService, IUserService userService, IContentService contentService)
        {
            _contentResolver = contentResolver;
            _publishedSnapshotService = publishedSnapshotService;
            _userService = userService;
            _contentService = contentService;
        }

        [Route("{id:guid}")]
        [ResponseType(typeof(ContentModel))]
        public IHttpActionResult Get(Guid id)
        {
            var val = _publishedSnapshotService.EnterPreview(_userService.GetUserById(-1), _contentService.GetById(id).Id);

            IPublishedContent content = Umbraco.Content(id);

            ContentModel contentModel = _contentResolver.Value.ResolveContent(content);

            return Ok(contentModel);
        }
    }
}