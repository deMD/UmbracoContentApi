using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models;
using UmbracoContentApi.Core.Models;

namespace UmbracoContentApi.Core.Converters
{
    public class MultiUrlPickerConverter : IConverter
    {
        public string EditorAlias => "Umbraco.MultiUrlPicker";

        public object Convert(object value, Dictionary<string, object>? options = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), $"A value for {EditorAlias} is required.");
            }


            var links = new List<MultiLinkModel>();
            if (value is IEnumerable<Link> valueLinks)
            {
                foreach (Link link in valueLinks)
                {
                    links.Add(
                        new MultiLinkModel
                        {
                            Name = link.Name,
                            Target = link.Target,
                            Type = link.Type.ToString(),
                            Url = link.Url
                        });
                }

                return links;
            }

            if (value is Link valueLink)
            {
                return new MultiLinkModel
                {
                    Name = valueLink.Name,
                    Target = valueLink.Target,
                    Type = valueLink.Type.ToString(),
                    Url = valueLink.Url
                };
            }

            throw new ArgumentException("value is not a valid link");
        }
    }
}