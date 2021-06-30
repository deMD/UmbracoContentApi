using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using UmbracoContentApi.Core.Resolvers;

namespace UmbracoContentApi.Core.Composers
{
    // ReSharper disable once UnusedMember.Global
    internal class ResolversComposer : IUserComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddTransient<IContentResolver, ContentResolver>();
            builder.Services.AddTransient<IGridControlResolver, GridControlResolver>();
            builder.Services.AddTransient<IBlockListResolver, BlockListResolver>();
            builder.Services.AddTransient<IMediaResolver, MediaResolver>();

        }
    }
}