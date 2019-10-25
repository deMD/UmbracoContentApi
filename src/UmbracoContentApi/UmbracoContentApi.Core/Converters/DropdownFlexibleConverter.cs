using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class DropdownFlexibleConverter : IConverter
    {
        public string EditorAlias => "Umbraco.DropDown.Flexible";

        public object Convert(object value, Dictionary<string, object> options = null)
        {
            return value;
        }
    }
}
