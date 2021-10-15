using System;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using UmbracoContentApi.Core.Configuration;
using UmbracoContentApi.Core.Models.Grid;

namespace UmbracoContentApi.Core.Converters.Grid
{
    public class MediaConverter : IGridConverter
    {
        private readonly Uri? _cdnUrl;

        public MediaConverter(IOptions<ContentApiOptions> contentApiOptions)
        {
            Uri.TryCreate(contentApiOptions.Value.CdnUrl, UriKind.Absolute, out _cdnUrl);
        }

        public string EditorAlias => "media";

        public object? Convert(object? value)
        {
            var image = JsonConvert.DeserializeObject<Media>(value?.ToString() ?? "");
            return image != null
                ? new
                {
                    image.Id,
                    ImageUrl = _cdnUrl == null
                        ? new Uri(image.Image ?? string.Empty, UriKind.Relative)
                        : new Uri(_cdnUrl, image.Image)
                }
                : null;
        }
    }
}