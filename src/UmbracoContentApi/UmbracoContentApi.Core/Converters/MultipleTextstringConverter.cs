using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class MultipleTextstringConverter : IConverter
    {
        public string EditorAlias => "Umbraco.MultipleTextstring";

        public object Convert(object value, Dictionary<string, object> options = null)
        {
            return value;
        }
    }
}
