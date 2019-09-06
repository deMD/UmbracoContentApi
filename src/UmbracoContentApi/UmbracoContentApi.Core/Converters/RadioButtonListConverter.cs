namespace UmbracoContentApi.Core.Converters
{
    public class RadioButtonListConverter : IConverter
    {
        public string EditorAlias => "Umbraco.RadioButtonList";

        public object Convert(object value)
        {
            return value;
        }
    }
}
