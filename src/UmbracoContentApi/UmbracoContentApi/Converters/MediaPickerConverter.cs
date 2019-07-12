using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using UmbracoContentApi.Models;

namespace UmbracoContentApi.Converters
{
    internal class MediaPickerConverter : IConverter
    {
        public string EditorAlias => "Umbraco.MediaPicker";

        public object Convert(object value)
        {
            if (value is IEnumerable<IPublishedContent> ar)
            {
                return ar.Select(t => new LinkModel {Id = t.Key, LinkType = "Asset"}).ToList();
            }

            return new LinkModel {Id = ((IPublishedContent) value).Key, LinkType = "Asset"};
        }
    }
}