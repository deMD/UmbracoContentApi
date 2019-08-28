namespace UmbracoContentApi.Core.Converters
{
    internal class TagsConverter : IConverter
    {
        public string EditorAlias => "Umbraco.Tags";

        public object Convert(object value)
        {
            return value;
        }
    }
}
