using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class ColorPickerConverter : IConverter
    {
        public string EditorAlias => "Umbraco.ColorPicker";

        public object Convert(object value, params KeyValuePair<string, object>[] options)
        {
            return value;
        }
    }
}
