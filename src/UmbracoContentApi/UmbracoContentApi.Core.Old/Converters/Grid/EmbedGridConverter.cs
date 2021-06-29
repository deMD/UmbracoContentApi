using System;

namespace UmbracoContentApi.Core.Converters.Grid
{
    public class EmbedGridConverter : IGridConverter
    {
        public string EditorAlias => "embed";

        public object Convert(object value)
        {
            if (value == null)
            {
                throw new ArgumentException(nameof(value));
            }

            return value;
        }
    }
}