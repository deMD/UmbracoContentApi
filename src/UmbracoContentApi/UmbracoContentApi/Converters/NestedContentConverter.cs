using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using UmbracoContentApi.Enums;
using UmbracoContentApi.Models;
using UmbracoContentApi.Resolvers;

namespace UmbracoContentApi.Converters
{
    internal class NestedContentConverter : IConverter
    {
        private readonly Lazy<IContentResolver> _contentResolver;

        public NestedContentConverter(Lazy<IContentResolver> contentResolver)
        {
            _contentResolver = contentResolver;
        }

        public string EditorAlias => "Umbraco.NestedContent";

        public object Convert(object value)
        {
            var models = new List<ContentModel>();
            foreach (var element in (IEnumerable<IPublishedElement>) value)
            {
                var model = _contentResolver.Value.ResolveContent(element);

                models.Add(model);
            }

            return models;


            //var list = new List<LinkModel>();
            //foreach (IPublishedElement element in (IEnumerable<IPublishedElement>) value)
            //{
            //    list.Add(
            //        new LinkModel
            //        {
            //            Id = element.Key,
            //            LinkType = LinkTypeResolver.GetLinkType(element.ContentType.ItemType)
            //        });
            //}

            //return list;
        }
    }
}