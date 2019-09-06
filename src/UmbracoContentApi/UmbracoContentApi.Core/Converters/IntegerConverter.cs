namespace UmbracoContentApi.Core.Converters
{
    public class IntegerConverter : IConverter
    {
        public string EditorAlias => "Umbraco.Integer";

        public object Convert(object value)
        {
            return value;
        }
    }
}
