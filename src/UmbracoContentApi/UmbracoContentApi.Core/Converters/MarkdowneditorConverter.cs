namespace UmbracoContentApi.Core.Converters
{
    public class MarkdowneditorConverter : IConverter
    {
        public string EditorAlias => "Umbraco.MarkdownEditor";

        public object Convert(object value)
        {
            return value;
        }
    }
}
