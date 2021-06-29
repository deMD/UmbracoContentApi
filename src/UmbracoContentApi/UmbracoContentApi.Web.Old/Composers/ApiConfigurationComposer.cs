using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace UmbracoContentApi.Web.Composers
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    internal class ApiConfigurationComposer : IComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Insert<ApiConfigurationComponent>();
        }

        public class ApiConfigurationComponent : IComponent
        {
            public void Initialize()
            {
                RouteTable.Routes.MapMvcAttributeRoutes();
                GlobalConfiguration.Configuration.MapHttpAttributeRoutes();
                GlobalConfiguration.Configuration.Formatters.Clear();
                GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter
                {
                    SerializerSettings = new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        Formatting = Formatting.Indented
                    }
                });
            }

            public void Terminate()
            {
            }
        }
    }
}
