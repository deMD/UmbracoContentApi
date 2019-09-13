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

        public object Convert(object value)
        {
            return value;
        }
    }
}
