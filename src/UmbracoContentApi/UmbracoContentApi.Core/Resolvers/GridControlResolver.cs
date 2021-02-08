using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NPoco;
using Umbraco.Core.Logging;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web;
using UmbracoContentApi.Core.Converters;
using UmbracoContentApi.Core.Converters.Grid;
using UmbracoContentApi.Core.Models;
using UmbracoContentApi.Core.Models.Grid;

namespace UmbracoContentApi.Core.Resolvers
{
    public class GridControlResolver : IGridControlResolver
    {
        private readonly IEnumerable<IGridConverter> _gridConverters;
        private readonly ILogger _logger;

        public GridControlResolver(
            IEnumerable<IGridConverter> gridConverters,
            ILogger logger)
        {
            _gridConverters = gridConverters;
            _logger = logger;
        }


        public Control ResolveControl(Control control)
        {
            if (control == null)
            {
                throw new ArgumentException(nameof(control));
            }

            IGridConverter converter = _gridConverters.FirstOrDefault(x => x.EditorAlias.Equals(control.Editor.Alias));
            
            return converter == null
                ? new Control { Editor = control.Editor, Value = $"No converter implemented for editor: {control.Editor.Alias}" }
                : new Control { Editor = control.Editor, Value = converter.Convert(control.Value) };
        }
    }
}