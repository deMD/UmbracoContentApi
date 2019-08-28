namespace UmbracoContentApi.Core.Converters
{
    public interface IConverter
    {
        string EditorAlias { get; }

        object Convert(object value);
    }
}
