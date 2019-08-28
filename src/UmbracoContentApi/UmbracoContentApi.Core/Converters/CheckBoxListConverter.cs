namespace UmbracoContentApi.Core.Converters
{
    internal class CheckBoxListConverter : IConverter
    {
        public string EditorAlias => "Umbraco.CheckBoxList";

        public object Convert(object value)
        {
            return value;
        }
    }
}
