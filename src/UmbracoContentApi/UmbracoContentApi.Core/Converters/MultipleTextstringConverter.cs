namespace UmbracoContentApi.Core.Converters
{
    internal class MultipleTextstringConverter : IConverter
    {
        public string EditorAlias => "Umbraco.MultipleTextstring";

        public object Convert(object value)
        {
            return value;
        }
    }
}
