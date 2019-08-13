using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;

namespace UmbracoContentApi.Converters
{
    internal class MemberPickerConverter : IConverter
    {
        public string EditorAlias => "Umbraco.MemberPicker";

        public object Convert(object value)
        {
            return ((IPublishedContent)value).Name;
        }
    }
}
