using Umbraco.Core;
using Umbraco.Core.Composing;
using UmbracoContentApi.Core.Resolvers;

namespace UmbracoContentApi.Core.Composers
{
    // ReSharper disable once UnusedMember.Global
    internal class ResolversComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register<IContentResolver, ContentResolver>();
            composition.Register<IMediaResolver, MediaResolver>();
        }
    }
}