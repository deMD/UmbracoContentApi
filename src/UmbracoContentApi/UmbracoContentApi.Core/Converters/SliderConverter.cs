using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class SliderConverter : IConverter
    {
        public string EditorAlias => "Umbraco.Slider";

        public object Convert(object value, Dictionary<string, object> options = null)
        {
            return value;
        }
    }
}
