using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using NPoco;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Composing;
using Umbraco.Web.WebApi;
using UmbracoContentApi.Converters;
using UmbracoContentApi.Enums;
using UmbracoContentApi.Models;

namespace UmbracoContentApi.Controllers
{
    [RoutePrefix("api/assets")]
    public class AssetApiController : UmbracoApiController
    {
        private readonly IEnumerable<IConverter> _converters;
        private readonly UmbracoHelper _umbracoHelper;
        private readonly IVariationContextAccessor _variationContextAccessor;

        public AssetApiController(
            IVariationContextAccessor variationContextAccessor,
            IEnumerable<IConverter> converters)
        {
            _variationContextAccessor = variationContextAccessor;
            _converters = converters;
            _umbracoHelper = Current.UmbracoHelper;
        }

        [Route("{id:guid}")]
        [ResponseType(typeof(ContentModel))]
        public IHttpActionResult Get(Guid id)
        {
            IPublishedContent media = _umbracoHelper.Media(id);

            var mediaModel = new AssetModel
            {
                System = new SystemModel
                {
                    Id = media.Key,
                    ContentType = media.ContentType.Alias,
                    CreatedAt = media.CreateDate,
                    EditedAt = media.UpdateDate,
                    Locale = _variationContextAccessor.VariationContext.Culture,
                    Type = ContentType.Content.ToString(),
                    Revision = Services.ContentService.GetVersions(media.Id).Count()
                }
            };

            var dict = new Dictionary<string, object>();
            //dict.Add("Name", media.Name);
            //dict.Add("File", new
            //{
            //    Url = media.Url,
            //    Details = new
            //    {
            //        Size = media.GetProperty("umbracoBytes").Value(),
            //        // Only when image
            //        Image = new
            //        {
            //            Width = media.GetProperty("umbracoWidth").Value(),
            //            Height = media.GetProperty("umbracoHeight").Value()
            //        }
            //    }
            //});

            foreach (IPublishedProperty property in media.Properties)
            {
                IConverter converter =
                    _converters.FirstOrDefault(x => x.EditorAlias.Equals(property.PropertyType.EditorAlias));
                if (converter != null)
                {
                    object prop = property.Value();
                    prop = converter.Convert(prop);
                    dict.Add(property.Alias, prop);
                }
                else
                {
                    dict.Add(
                        property.Alias,
                        $"No converter implemented for editor: {property.PropertyType.EditorAlias}");
                }
            }

            mediaModel.Fields = dict;

            return Ok(mediaModel);
        }
    }
}