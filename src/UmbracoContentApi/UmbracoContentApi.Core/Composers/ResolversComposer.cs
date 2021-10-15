using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using UmbracoContentApi.Core.Configuration;
using UmbracoContentApi.Core.Resolvers;

namespace UmbracoContentApi.Core.Composers
{
    // ReSharper disable once UnusedMember.Global
    internal class ResolversComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.Configure<ContentApiOptions>(builder.Config.GetSection(ContentApiOptions.Section));

            builder.Services.AddTransient<IContentResolver, ContentResolver>();
            builder.Services.AddTransient<IGridControlResolver, GridControlResolver>();
            builder.Services.AddTransient<IBlockListResolver, BlockListResolver>();
            builder.Services.AddTransient<IMediaResolver, MediaResolver>();

        }
    }
}