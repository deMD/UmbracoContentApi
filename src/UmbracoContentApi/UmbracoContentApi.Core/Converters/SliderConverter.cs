namespace UmbracoContentApi.Core.Converters
{
    internal class SliderConverter : IConverter
    {
        public string EditorAlias => "Umbraco.Slider";

        public object Convert(object value)
        {
            return value;
        }
    }
}
