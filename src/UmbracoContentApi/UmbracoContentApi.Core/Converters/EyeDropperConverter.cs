using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class EyeDropperConverter : IConverter
    {
        public string EditorAlias => "Umbraco.ColorPicker.EyeDropper";

        public object Convert(object value, Dictionary<string, object>? options = null)
        {
            return value;
        }
    }
}
