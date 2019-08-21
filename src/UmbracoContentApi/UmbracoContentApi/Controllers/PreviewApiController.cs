using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Composing;
using Umbraco.Web.PublishedCache;
using Umbraco.Web.WebApi;
using UmbracoContentApi.Converters;
using UmbracoContentApi.Enums;
using UmbracoContentApi.Models;
using UmbracoContentApi.Resolvers;

namespace UmbracoContentApi.Controllers
{
    [RoutePrefix("api/preview")]
    public class PreviewApiController : UmbracoApiController
    {
        private readonly Lazy<IContentResolver> _contentResolver;
        private readonly UmbracoHelper _umbracoHelper;
        private readonly IPublishedSnapshotService _publishedSnapshotService;
        private readonly IUserService _userService;
        private readonly IContentService _contentService;

        public PreviewApiController(Lazy<IContentResolver> contentResolver, IPublishedSnapshotService publishedSnapshotService, IUserService userService, IContentService contentService)
        {
            _contentResolver = contentResolver;
            _publishedSnapshotService = publishedSnapshotService;
            _userService = userService;
            _contentService = contentService;
            _umbracoHelper = Current.UmbracoHelper;
        }

        [Route("{id:guid}")]
        [ResponseType(typeof(ContentModel))]
        public IHttpActionResult Get(Guid id)
        {
            var val = _publishedSnapshotService.EnterPreview(_userService.GetUserById(-1), _contentService.GetById(id).Id);

            IPublishedContent content = _umbracoHelper.Content(id);

            ContentModel contentModel = _contentResolver.Value.ResolveContent(content);

            return Ok(contentModel);
        }
    }
}