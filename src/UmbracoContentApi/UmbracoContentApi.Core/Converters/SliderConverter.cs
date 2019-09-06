namespace UmbracoContentApi.Core.Converters
{
    public class SliderConverter : IConverter
    {
        public string EditorAlias => "Umbraco.Slider";

        public object Convert(object value)
        {
            return value;
        }
    }
}
