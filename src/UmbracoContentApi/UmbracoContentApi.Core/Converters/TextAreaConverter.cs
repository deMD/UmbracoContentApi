namespace UmbracoContentApi.Core.Converters
{
    public class TextAreaConverter : IConverter
    {
        public string EditorAlias => "Umbraco.TextArea";

        public object Convert(object value)
        {
            return value;
        }
    }
}
