namespace UmbracoContentApi.Core.Converters
{
    public class TextBoxConverter : IConverter
    {
        public string EditorAlias => "Umbraco.TextBox";

        public object Convert(object value)
        {
            return value;
        }
    }
}
