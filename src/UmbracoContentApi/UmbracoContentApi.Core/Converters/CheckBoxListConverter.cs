namespace UmbracoContentApi.Core.Converters
{
    public class CheckBoxListConverter : IConverter
    {
        public string EditorAlias => "Umbraco.CheckBoxList";

        public object Convert(object value)
        {
            return value;
        }
    }
}
