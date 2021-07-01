using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Extensions;
using UmbracoContentApi.Core.Converters;

namespace UmbracoContentApi.Core.Composers
{
    // ReSharper disable once UnusedMember.Global
    public class ConvertersComposer : IUserComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            IEnumerable<Type> converters =
                GetType().Assembly.GetTypes().Where(x => x.Implements<IConverter>() && x.IsClass);
            foreach (Type converter in converters)
            {
                builder.Converters().Append(converter);
            }

            builder.BlockConverters();
        }
    }
}