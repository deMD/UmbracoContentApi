using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Media;
using Umbraco.Cms.Core.PropertyEditors.ValueConverters;
using UmbracoContentApi.Core.Configuration;

namespace UmbracoContentApi.Core.Converters
{
    public class ImageCropperConverter : IConverter
    {
        private readonly string? _cdnUrl;
        private readonly IImageUrlGenerator _imageUrlGenerator;

        public ImageCropperConverter(IImageUrlGenerator imageUrlGenerator,
            IOptions<ContentApiOptions>? contentApiOptions)
        {
            _cdnUrl = contentApiOptions?.Value.CdnUrl;
            _imageUrlGenerator = imageUrlGenerator;
        }

        public string EditorAlias => "Umbraco.ImageCropper";

        public object Convert(object value, Dictionary<string, object>? options = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), $"A value for {EditorAlias} is required.");
            }

            var ctn = (ImageCropperValue) value;

            var crops = ctn.Crops?.ToList();
            var cropUrls = new Dictionary<string, string>();

            // ReSharper disable once InvertIf
            if (crops?.Any() != null)
            {
                if (string.IsNullOrWhiteSpace(_cdnUrl))
                {
                    foreach (var crop in crops)
                    {
                        cropUrls.Add(
                            crop.Alias,
                            new Uri(ctn.Src + ctn.GetCropUrl(crop.Alias, _imageUrlGenerator), UriKind.Relative)
                                .ToString());
                    }
                }
                else
                {
                    foreach (var crop in crops)
                    {
                        cropUrls.Add(
                            crop.Alias,
                            new Uri(new Uri(_cdnUrl), ctn.Src + ctn.GetCropUrl(crop.Alias, _imageUrlGenerator))
                                .ToString());
                    }
                }
            }

            return new
            {
                Src = string.IsNullOrWhiteSpace(_cdnUrl)
                    ? new Uri(ctn.Src, UriKind.Relative).ToString()
                    : new Uri(new Uri(_cdnUrl), ctn.Src).ToString(),
                Crops = cropUrls
            };
        }
    }
}