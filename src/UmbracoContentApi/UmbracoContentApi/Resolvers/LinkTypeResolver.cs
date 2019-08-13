using System;
using Umbraco.Core.Models.PublishedContent;
using UmbracoContentApi.Enums;

namespace UmbracoContentApi.Resolvers
{
    internal static class LinkTypeResolver
    {
        public static string GetLinkType(PublishedItemType itemType)
        {
            switch (itemType)
            {
                case PublishedItemType.Unknown:
                    return "";
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