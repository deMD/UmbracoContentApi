using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class UploadFieldConverter : IConverter
    {
        public string EditorAlias => "Umbraco.UploadField";

        public object Convert(object value, Dictionary<string, object>? options = null)
        {
            return value;
        }
    }
}
