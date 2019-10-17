using System;
using System.Collections.Generic;
using Umbraco.Web.Models;
using UmbracoContentApi.Core.Models;

namespace UmbracoContentApi.Core.Converters
{
    public class MultiUrlPickerConverter : IConverter
    {
        public string EditorAlias => "Umbraco.MultiUrlPicker";

        public object Convert(object value, params KeyValuePair<string, object>[] options)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), $"A value for {EditorAlias} is required.");
            }

            var links = new List<MulitLinkModel>();
            foreach (Link link in (IEnumerable<object>) value)
            {
                links.Add(
                    new MulitLinkModel
                    {
                        Name = link.Name,
                        Target = link.Target,
                        Type = link.Type.ToString(),
                        Url = link.Url
                    });
            }

            return links;
        }
    }
}