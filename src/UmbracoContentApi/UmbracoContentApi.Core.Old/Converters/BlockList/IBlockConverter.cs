namespace UmbracoContentApi.Core.Converters.BlockList
{
    public interface IBlockConverter
    {
        string EditorAlias { get; }

        object Convert(object value);
    }
}
