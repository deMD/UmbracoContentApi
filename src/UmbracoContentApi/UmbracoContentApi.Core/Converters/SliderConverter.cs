using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class SliderConverter : IConverter
    {
        public string EditorAlias => "Umbraco.Slider";

        public object Convert(object value, params KeyValuePair<string, object>[] options)
        {
            return value;
        }
    }
}
