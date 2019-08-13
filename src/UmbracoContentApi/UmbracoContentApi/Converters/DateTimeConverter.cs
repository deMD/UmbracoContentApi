using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbracoContentApi.Converters
{
    internal class DateTimeConverter : IConverter
    {
        public string EditorAlias => "Umbraco.DateTime";

        public object Convert(object value)
        {
            return value;
        }
    }
}
