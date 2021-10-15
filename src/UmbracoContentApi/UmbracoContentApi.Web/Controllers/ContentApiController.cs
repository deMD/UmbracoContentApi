using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core;
using Umbraco.Cms.Web.Common.Controllers;
using UmbracoContentApi.Core.Resolvers;

namespace UmbracoContentApi.Web.Controllers
{
    [Route("api/content")]
    public class ContentApiController : UmbracoApiController
    {
        private readonly Lazy<IContentResolver> _contentResolver;
        private readonly IPublishedContentQuery _publishedContent;

        public ContentApiController(
            Lazy<IContentResolver> contentResolver, IPublishedContentQuery publishedContent)
        {
            _contentResolver = contentResolver;
            _publishedContent = publishedContent;
        }

        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id, int level = 0)
        {
            var content = _publishedContent.Content(id);
            var dictionary = new Dictionary<string, object>
            {
                {"addUrl", true}
            };

            if (level <= 0)
            {
                return Ok(_contentResolver.Value.ResolveContent(content, dictionary));
            }

            dictionary.Add("level", level);

            return Ok(_contentResolver.Value.ResolveContent(content, dictionary));
        }
    }
}