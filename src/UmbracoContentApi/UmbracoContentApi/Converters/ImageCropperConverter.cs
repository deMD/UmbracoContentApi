using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbracoContentApi.Converters
{
    internal class ImageCropperConverter : IConverter
    {
        public string EditorAlias => "Umbraco.ImageCropper";

        public object Convert(object value)
        {
            return "Awaiting Asset implementation";
        }
    }
}
