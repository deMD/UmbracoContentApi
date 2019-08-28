using Umbraco.Core.Models.PublishedContent;

namespace UmbracoContentApi.Core.Converters
{
    internal class MemberPickerConverter : IConverter
    {
        public string EditorAlias => "Umbraco.MemberPicker";

        public object Convert(object value)
        {
            return ((IPublishedContent)value).Name;
        }
    }
}
