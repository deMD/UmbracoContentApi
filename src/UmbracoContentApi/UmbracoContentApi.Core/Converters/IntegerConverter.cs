namespace UmbracoContentApi.Core.Converters
{
    internal class IntegerConverter : IConverter
    {
        public string EditorAlias => "Umbraco.Integer";

        public object Convert(object value)
        {
            return value;
        }
    }
}
