using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbracoContentApi.Converters
{
    class UploadFieldConverter : IConverter
    {
        public string EditorAlias => "Umbraco.UploadField";

        public object Convert(object value)
        {
            return value;
        }
    }
}
