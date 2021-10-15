using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UmbracoContentApi.Core.Models.Grid;
using UmbracoContentApi.Core.Resolvers;

namespace UmbracoContentApi.Core.Converters
{
    public class UmbracoGridConverter : IConverter
    {
        private readonly Lazy<IGridControlResolver> _gridControlResolver;

        public UmbracoGridConverter(Lazy<IGridControlResolver> gridControlResolver)
        {
            _gridControlResolver = gridControlResolver;
        }

        public object? Convert(object value, Dictionary<string, object>? options = null)
        {
            if (value is not JObject gridValue)
            {
                return null;
            }
            
            var typedValue = JsonConvert.DeserializeObject<Models.Grid.Grid>(gridValue.ToString());

            if (options != null &&
                options.ContainsKey("flattenGrid") &&
                bool.TryParse(options["flattenGrid"].ToString(), out var flattenGrid) &&
                flattenGrid)
            {
                return typedValue?.Sections?.SelectMany(
                    s => s.Rows?.SelectMany(
                        r => r.Areas?.SelectMany(
                            a => a.Controls?.Select(_gridControlResolver.Value.ResolveControl) ?? Array.Empty<Control>()
                        ) ?? Array.Empty<Control>()) ?? Array.Empty<Control>());
            }

            return new Models.Grid.Grid
            {
                Name = typedValue?.Name,
                NrOfColumns = typedValue?.Sections?.Sum(x => int.Parse(x.Grid ?? "0")) ?? 0,
                Sections = typedValue?.Sections?.Select(
                    s => new Section
                    {
                        Grid = s.Grid,
                        ColumnWidth = int.Parse(s.Grid ?? "0"),
                        Rows = s.Rows?.Select(
                            r => new Row
                            {
                                Name = r.Name,
                                NrOfColumns = typedValue.Sections.Sum(x => int.Parse(x.Grid ?? "0")),
                                Areas = r.Areas?.Select(
                                    a => new Area
                                    {
                                        Grid = a.Grid,
                                        ColumnWidth = int.Parse(a.Grid ?? "0"),
                                        Controls = a.Controls?.Select(_gridControlResolver.Value.ResolveControl)
                                    })
                            })
                    })
            };
        }

        public string EditorAlias => "Umbraco.Grid";
    }
}