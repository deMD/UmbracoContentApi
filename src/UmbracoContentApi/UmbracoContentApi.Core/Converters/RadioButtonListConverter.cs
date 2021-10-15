using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class RadioButtonListConverter : IConverter
    {
        public string EditorAlias => "Umbraco.RadioButtonList";

        public object Convert(object value, Dictionary<string, object>? options = null)
        {
            return value;
        }
    }
}
