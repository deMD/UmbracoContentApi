using System.Collections.Generic;

namespace UmbracoContentApi.Core.Converters
{
    public interface IConverter
    {
        string EditorAlias { get; }

        object Convert(object value, Dictionary<string, object> options = null);
    }
}