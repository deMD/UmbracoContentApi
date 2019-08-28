namespace UmbracoContentApi.Core.Converters
{
    internal class DateTimeConverter : IConverter
    {
        public string EditorAlias => "Umbraco.DateTime";

        public object Convert(object value)
        {
            return value;
        }
    }
}
