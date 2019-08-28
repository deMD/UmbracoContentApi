namespace UmbracoContentApi.Core.Converters
{
    internal class DropdownFlexibleConverter : IConverter
    {
        public string EditorAlias => "Umbraco.DropDown.Flexible";

        public object Convert(object value)
        {
            return value;
        }
    }
}
