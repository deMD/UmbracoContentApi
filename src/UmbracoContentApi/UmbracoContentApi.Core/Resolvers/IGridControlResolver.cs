using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;
using UmbracoContentApi.Core.Models;
using UmbracoContentApi.Core.Models.Grid;

namespace UmbracoContentApi.Core.Resolvers
{
    public interface IGridControlResolver
    {
        Control ResolveControl(Control control);
    }
}