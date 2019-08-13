using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbracoContentApi.Converters
{
    internal class RadioButtonListConverter : IConverter
    {
        public string EditorAlias => "Umbraco.RadioButtonList";

        public object Convert(object value)
        {
            return value;
        }
    }
}
