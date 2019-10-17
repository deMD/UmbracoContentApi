using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class DropdownFlexibleConverter : IConverter
    {
        public string EditorAlias => "Umbraco.DropDown.Flexible";

        public object Convert(object value, params KeyValuePair<string, object>[] options)
        {
            return value;
        }
    }
}
