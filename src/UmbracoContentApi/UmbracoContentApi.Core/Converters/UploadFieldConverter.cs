using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public class UploadFieldConverter : IConverter
    {
        public string EditorAlias => "Umbraco.UploadField";

        public object Convert(object value, params KeyValuePair<string, object>[] options)
        {
            return value;
        }
    }
}
