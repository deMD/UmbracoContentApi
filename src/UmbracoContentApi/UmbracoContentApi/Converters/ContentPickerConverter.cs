using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;
using UmbracoContentApi.Models;

namespace UmbracoContentApi.Converters
{
    internal class ContentPickerConverter : IConverter
    {
        public string EditorAlias => "Umbraco.ContentPicker";

        public object Convert(object value)
        {
            return new LinkModel
            {
                Id = ((IPublishedContent)value).Key,
                LinkType = "Entry"
            };
        }
    }
}
