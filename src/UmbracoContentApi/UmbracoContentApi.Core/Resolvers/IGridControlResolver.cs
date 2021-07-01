using UmbracoContentApi.Core.Models.Grid;

namespace UmbracoContentApi.Core.Resolvers
{
    public interface IGridControlResolver
    {
        Control ResolveControl(Control control);
    }
}