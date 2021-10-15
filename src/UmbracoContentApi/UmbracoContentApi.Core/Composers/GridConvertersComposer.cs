using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Extensions;
using UmbracoContentApi.Core.Converters.Grid;

namespace UmbracoContentApi.Core.Composers
{
    // ReSharper disable once UnusedMember.Global
    public class GridConvertersComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            IEnumerable<Type> gridConverters =
                GetType().Assembly.GetTypes().Where(x => x.Implements<IGridConverter>() && x.IsClass);
            foreach (Type gridConverter in gridConverters)
            {
                builder.GridConverters().Append(gridConverter);
            }
        }
    }
}