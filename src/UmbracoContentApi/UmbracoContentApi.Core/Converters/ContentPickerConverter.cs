using Umbraco.Core.Models.PublishedContent;
using UmbracoContentApi.Core.Enums;
using UmbracoContentApi.Core.Models;

namespace UmbracoContentApi.Core.Converters
{
    public class ContentPickerConverter : IConverter
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