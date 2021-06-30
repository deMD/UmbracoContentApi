using System;
using System.Collections.Generic;
using System.Linq;
using UmbracoContentApi.Core.Builder;
using UmbracoContentApi.Core.Converters.Grid;
using UmbracoContentApi.Core.Models.Grid;

namespace UmbracoContentApi.Core.Resolvers
{
    public class GridControlResolver : IGridControlResolver
    {
        private readonly GridConverterCollection _gridConverters;

        public GridControlResolver(
            GridConverterCollection gridConverters)
        {
            _gridConverters = gridConverters;
        }


        public Control ResolveControl(Control control)
        {
            if (control == null)
            {
                throw new ArgumentException("The Control can't be resolved", nameof(control));
            }

            var converter = _gridConverters.FirstOrDefault(x => x.EditorAlias.Equals(control.Editor.Alias));

            return converter == null
                ? new Control
                    {Editor = control.Editor, Value = $"No converter implemented for editor: {control.Editor.Alias}"}
                : new Control {Editor = control.Editor, Value = converter.Convert(control.Value)};
        }
    }
}