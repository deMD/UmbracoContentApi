using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Umbraco.Cms.Core.Media;
using Umbraco.Cms.Core.PropertyEditors.ValueConverters;

namespace UmbracoContentApi.Core.Converters
{
    public class ImageCropperConverter : IConverter
    {
        private readonly IImageUrlGenerator _imageUrlGenerator;

        public ImageCropperConverter(IImageUrlGenerator imageUrlGenerator)
        {
            _imageUrlGenerator = imageUrlGenerator;
        }

        public string EditorAlias => "Umbraco.ImageCropper";

        public object Convert(object value, Dictionary<string, object> options = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), $"A value for {EditorAlias} is required.");
            }

            var ctn = (ImageCropperValue)value;

            List<ImageCropperValue.ImageCropperCrop> crops = ctn.Crops?.ToList();
            var cropUrls = new Dictionary<string, string>();

            string cdnUrl = ConfigurationManager.AppSettings["ContentApi:CdnUrl"];

            // ReSharper disable once InvertIf
            if (crops?.Any() != null)
            {
                if (string.IsNullOrWhiteSpace(cdnUrl))
                {
                    foreach (ImageCropperValue.ImageCropperCrop crop in crops)
                    {
                        cropUrls.Add(
                            crop.Alias,
                            new Uri(ctn.Src + ctn.GetCropUrl(crop.Alias, _imageUrlGenerator), UriKind.Relative).ToString());
                    }
                }
                else
                {
                    foreach (ImageCropperValue.ImageCropperCrop crop in crops)
                    {
                        cropUrls.Add(
                            crop.Alias,
                            new Uri(new Uri(cdnUrl), ctn.Src + ctn.GetCropUrl(crop.Alias, _imageUrlGenerator)).ToString());
                    }
                }
            }

            return new
            {
                Src = string.IsNullOrWhiteSpace(cdnUrl)
                    ? new Uri(ctn.Src, UriKind.Relative).ToString()
                    : new Uri(new Uri(cdnUrl), ctn.Src).ToString(),
                Crops = cropUrls
            };
        }
    }
}