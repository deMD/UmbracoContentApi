using System;

namespace UmbracoContentApi.Core.Converters.Grid
{
    public class QuoteGridConverter : IGridConverter
    {
        public string EditorAlias => "quote";

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