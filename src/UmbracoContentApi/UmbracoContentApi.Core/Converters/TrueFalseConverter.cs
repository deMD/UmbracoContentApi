namespace UmbracoContentApi.Core.Converters
{
    internal class TrueFalseConverter : IConverter
    {
        public string EditorAlias => "Umbraco.TrueFalse";

        public object Convert(object value)
        {
            return value;
        }
    }
}
