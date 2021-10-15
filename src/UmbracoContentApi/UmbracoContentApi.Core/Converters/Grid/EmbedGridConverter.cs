using System;
using Newtonsoft.Json;
using UmbracoContentApi.Core.Models;

namespace UmbracoContentApi.Core.Converters.Grid
{
    public class EmbedGridConverter : IGridConverter
    {
        public string EditorAlias => "embed";

        public object? Convert(object? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return JsonConvert.DeserializeObject<EmbedModel>(value.ToString() ?? string.Empty);
        }
    }
}