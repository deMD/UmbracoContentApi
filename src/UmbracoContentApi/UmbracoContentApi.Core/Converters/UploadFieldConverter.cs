namespace UmbracoContentApi.Core.Converters
{
    internal class UploadFieldConverter : IConverter
    {
        public string EditorAlias => "Umbraco.UploadField";

        public object Convert(object value)
        {
            return value;
        }
    }
}
