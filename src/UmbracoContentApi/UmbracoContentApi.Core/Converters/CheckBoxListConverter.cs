using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class CheckBoxListConverter : IConverter
    {
        public string EditorAlias => "Umbraco.CheckBoxList";

        public object Convert(object value, Dictionary<string, object>? options = null)
        {
            return value;
        }
    }
}
