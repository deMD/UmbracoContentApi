using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbracoContentApi.Converters
{
    internal class DropdownFlexibleConverter : IConverter
    {
        public string EditorAlias => "Umbraco.DropDown.Flexible";

        public object Convert(object value)
        {
            return value;
        }
    }
}
