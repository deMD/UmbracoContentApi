using System;
using Umbraco.Cms.Core.Models.PublishedContent;
using UmbracoContentApi.Core.Enums;

namespace UmbracoContentApi.Core.Resolvers
{
    public static class LinkTypeResolver
    {
        public static string GetLinkType(PublishedItemType itemType)
        {
            switch (itemType)
            {
                case PublishedItemType.Unknown:
                    return string.Empty;
                case PublishedItemType.Element:
                    return LinkType.Element.ToString();
                case PublishedItemType.Content:
                    return LinkType.Content.ToString();
                case PublishedItemType.Media:
                    return LinkType.Media.ToString();
                case PublishedItemType.Member:
                    return LinkType.Member.ToString();
                default:
                    throw new ArgumentOutOfRangeException(nameof(itemType), itemType, null);
            }
        }
    }
}