namespace UmbracoContentApi.Core.Converters
{
    public class LabelConverter : IConverter
    {
        public string EditorAlias => "Umbraco.Label";

        public object Convert(object value)
        {
            return value;
        }
    }
}
