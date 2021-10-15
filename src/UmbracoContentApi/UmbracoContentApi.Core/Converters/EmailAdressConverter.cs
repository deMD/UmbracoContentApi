using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class EmailAdressConverter : IConverter
    {
        public string EditorAlias => "Umbraco.EmailAddress";

        public object Convert(object value, Dictionary<string, object>? options = null)
        {
            // If the value is already in a json supported format, just return it.
            // Otherwise convert it to a friendly format here.
            return value;
        }
    }
}