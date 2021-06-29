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
            builder.Services.AddScoped<IContentResolver, ContentResolver>();
            builder.Services.AddScoped<IGridControlResolver, GridControlResolver>();
            builder.Services.AddScoped<IBlockListResolver, BlockListResolver>();
            builder.Services.AddScoped<IMediaResolver, MediaResolver>();

        }
    }
}