using Umbraco.Core.Models.PublishedContent;
using UmbracoContentApi.Enums;
using UmbracoContentApi.Models;

namespace UmbracoContentApi.Converters
{
    internal class ContentPickerConverter : IConverter
    {
        public string EditorAlias => "Umbraco.ContentPicker";

        public object Convert(object value)
        {
            return new LinkModel
            {
                Id = ((IPublishedContent) value).Key,
                LinkType = LinkType.Content.ToString()
            };
        }
    }
}