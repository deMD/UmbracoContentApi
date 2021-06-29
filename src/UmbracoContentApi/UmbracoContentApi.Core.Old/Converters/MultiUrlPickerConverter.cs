using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Umbraco.Web.Models;
using UmbracoContentApi.Core.Models;

namespace UmbracoContentApi.Core.Converters
{
    public class MultiUrlPickerConverter : IConverter
    {
        public string EditorAlias => "Umbraco.MultiUrlPicker";

        public object Convert(object value, Dictionary<string, object> options = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), $"A value for {EditorAlias} is required.");
            }

            

            var links = new List<MulitLinkModel>();
            if(value is IEnumerable<Link> valueLinks)
            {
                foreach (Link link in valueLinks)
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
            if (value is Link valueLink)
            {
                return new MulitLinkModel
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