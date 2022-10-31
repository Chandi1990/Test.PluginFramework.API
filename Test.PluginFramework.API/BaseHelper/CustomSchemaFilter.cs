using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Test.PluginFramework.API.BaseHelper
{
    public class CustomSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            var excludeProps = new[] { "CorrelationId" };

            foreach (var prop in excludeProps)
            {
                if (schema.Properties.ContainsKey(prop))
                    schema.Properties.Remove(prop);
            }
        }
    }
}
