using System;

namespace UmbracoContentApi.Core.Converters.Grid
{
    public class HeadlineGridConverter : IGridConverter
    {
        public string EditorAlias => "headline";

        public object Convert(object? value)
        {
            if (value == null)
            {
                throw new ArgumentException(nameof(value));
            }

            return value;
        }
    }
}