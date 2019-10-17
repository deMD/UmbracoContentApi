using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class RadioButtonListConverter : IConverter
    {
        public string EditorAlias => "Umbraco.RadioButtonList";

        public object Convert(object value, params KeyValuePair<string, object>[] options)
        {
            return value;
        }
    }
}
