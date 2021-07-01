namespace UmbracoContentApi.Core.Converters.Grid
{
    public interface IGridConverter
    {
        string EditorAlias { get; }

        object Convert(object value);
    }
}
