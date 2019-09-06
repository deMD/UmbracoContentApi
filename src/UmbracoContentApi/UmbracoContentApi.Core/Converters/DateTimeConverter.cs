namespace UmbracoContentApi.Core.Converters
{
    public class DateTimeConverter : IConverter
    {
        public string EditorAlias => "Umbraco.DateTime";

        public object Convert(object value)
        {
            return value;
        }
    }
}
