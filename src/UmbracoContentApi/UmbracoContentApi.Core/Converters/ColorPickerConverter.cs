namespace UmbracoContentApi.Core.Converters
{
    internal class ColorPickerConverter : IConverter
    {
        public string EditorAlias => "Umbraco.ColorPicker";

        public object Convert(object value)
        {
            return value;
        }
    }
}
