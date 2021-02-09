using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Composing;
using UmbracoContentApi.Core.Converters.Grid;

namespace UmbracoContentApi.Core.Composers
{
    // ReSharper disable once UnusedMember.Global
    public class GridConvertersComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            IEnumerable<Type> gridConverters =
                GetType().Assembly.GetTypes().Where(x => x.Implements<IGridConverter>() && x.IsClass);
            foreach (Type gridConverter in gridConverters)
            {
                composition.GridConverters().Append(gridConverter);
            }
        }
    }
}