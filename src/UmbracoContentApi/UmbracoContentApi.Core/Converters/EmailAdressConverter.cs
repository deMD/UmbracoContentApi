using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbracoContentApi.Core.Converters
{
    public class EmailAdressConverter : IConverter
    {
        public string EditorAlias => "Umbraco.EmailAddress";

        public object Convert(object value, params KeyValuePair<string, object>[] options)
        {
            // If the value is already in a json supported format, just return it.
            // Otherwise convert it to a friendly format here.
            return value;
        }
    }
}
