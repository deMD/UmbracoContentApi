namespace UmbracoContentApi.Core.Converters
{
    public class TagsConverter : IConverter
    {
        public string EditorAlias => "Umbraco.Tags";

        public object Convert(object value)
        {
            return value;
        }
    }
}
