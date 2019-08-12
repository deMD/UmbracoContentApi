using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace UmbracoContentApi.Web.Swagger
{
    internal class UmbracoBackOfficeSwaggerFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            IEnumerable<KeyValuePair<string, PathItem>> itemsToRemove = swaggerDoc.paths.Where(
                x =>
                {
                    string key = x.Key.ToLower();
                    return key.Contains("umbraco/backoffice") ||
                           key.Contains("install/api") ||
                           key.Contains("umbraco/api");
                });
            Dictionary<string, PathItem> routes = swaggerDoc.paths.ToDictionary(x => x.Key, y => y.Value);
            foreach (KeyValuePair<string, PathItem> itemToRemove in itemsToRemove)
            {
                routes.Remove(itemToRemove.Key);
            }

            swaggerDoc.paths = routes;
        }
    }
}