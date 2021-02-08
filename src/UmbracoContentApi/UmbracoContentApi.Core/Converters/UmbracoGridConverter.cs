using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Umbraco.Core.Models;
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

        public object Convert(object value, Dictionary<string, object> options = null)
        {
            var typedValue = JsonConvert.DeserializeObject<Models.Grid.Grid>(value.ToString());

            if (options != null &&
                options.ContainsKey("flattenGrid") &&
                bool.TryParse(options["flattenGrid"].ToString(), out bool flattenGrid) &&
                flattenGrid)
            {
                return typedValue.Sections.SelectMany(
                    s => s.Rows.SelectMany(
                        r => r.Areas.SelectMany(
                            a => a.Controls.Select(_gridControlResolver.Value.ResolveControl)
                        )));
            }

            return new Models.Grid.Grid
            {
                NrOfColumns = typedValue.Sections.Sum(x => int.Parse(x.Grid)),
                Sections = typedValue.Sections.Select(
                    s => new Section
                    {
                        ColumnWidth = int.Parse(s.Grid),
                        Rows = s.Rows.Select(
                            r => new Row
                            {
                                NrOfColumns = typedValue.Sections.Sum(x => int.Parse(x.Grid)),
                                Areas = r.Areas.Select(
                                    a => new Area
                                    {
                                        ColumnWidth = int.Parse(s.Grid),
                                        Controls = a.Controls.Select(_gridControlResolver.Value.ResolveControl)
                                    })
                            })
                    })
            };
        }

        public string EditorAlias => "Umbraco.Grid";
    }
}