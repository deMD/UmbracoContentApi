using System.Linq;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Extensions;
using UmbracoContentApi.Core.Converters;

namespace UmbracoContentApi.Core.Composers
{
    // ReSharper disable once UnusedMember.Global
    public class ConvertersComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            var converters =
                GetType().Assembly.GetTypes().Where(x => x.Implements<IConverter>() && x.IsClass);
            foreach (var converter in converters)
            {
                builder.Converters().Append(converter);
            }

            builder.BlockConverters();
        }
    }
}