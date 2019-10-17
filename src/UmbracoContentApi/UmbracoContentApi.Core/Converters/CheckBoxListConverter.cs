using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class CheckBoxListConverter : IConverter
    {
        public string EditorAlias => "Umbraco.CheckBoxList";

        public object Convert(object value, params KeyValuePair<string, object>[] options)
        {
            return value;
        }
    }
}
