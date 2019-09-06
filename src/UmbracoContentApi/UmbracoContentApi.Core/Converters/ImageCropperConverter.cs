using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.PropertyEditors.ValueConverters;

namespace UmbracoContentApi.Core.Converters
{
    internal class ImagePropperConverter : IConverter
    {
        public string EditorAlias => "Umbraco.ImageCropper";

        public object Convert(object value)
        {
            var ctn = (ImageCropperValue) value;

            List<ImageCropperValue.ImageCropperCrop> crops = ctn.Crops?.ToList();
            var cropUrls = new Dictionary<string,string>();
            // ReSharper disable once InvertIf
            if (crops?.Any() != null)
            {
                foreach (ImageCropperValue.ImageCropperCrop crop in crops)
                {
                    cropUrls.Add(crop.Alias, ctn.Src + ctn.GetCropUrl(crop.Alias));
                }
            }

            return new
            {
                Src ="Propper",
                Crops = "Propper"
            };
        }
    }
}