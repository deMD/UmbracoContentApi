namespace UmbracoContentApi.Core.Converters
{
    internal class MarkdowneditorConverter : IConverter
    {
        public string EditorAlias => "Umbraco.MarkdownEditor";

        public object Convert(object value)
        {
            return value;
        }
    }
}
