namespace UmbracoContentApi.Core.Converters
{
    public class ColorPickerConverter : IConverter
    {
        public string EditorAlias => "Umbraco.ColorPicker";

        public object Convert(object value)
        {
            return value;
        }
    }
}
