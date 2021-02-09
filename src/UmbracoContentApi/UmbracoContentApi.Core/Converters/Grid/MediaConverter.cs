using System;
using System.Configuration;
using Newtonsoft.Json;
using UmbracoContentApi.Core.Models.Grid;

namespace UmbracoContentApi.Core.Converters.Grid
{
    public class MediaConverter : IGridConverter
    {
        private readonly Uri _cdnUrl;
        
        public MediaConverter()
        {
            Uri.TryCreate(ConfigurationManager.AppSettings["ContentApi:CdnUrl"], UriKind.Absolute, out _cdnUrl);
        }

        public string EditorAlias => "media";

        public object Convert(object value)
        {
            var image = JsonConvert.DeserializeObject<Media>(value.ToString());
            return image != null
                ? new
                {
                    image.Id,
                    ImageUrl = _cdnUrl == null
                        ? new Uri(image.Image, UriKind.Relative)
                        : new Uri(_cdnUrl, image.Image)
                }
                : null;
        }
    }
}
