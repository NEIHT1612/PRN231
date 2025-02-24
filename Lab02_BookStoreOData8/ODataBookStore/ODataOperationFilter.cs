using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ODataBookStore
{
    public class ODataOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.RelativePath.Contains("Books"))
            {
                var keyParameter = operation.Parameters.FirstOrDefault(p => p.Name == "key");
                if (keyParameter != null)
                {
                    keyParameter.Name = "key";
                    keyParameter.In = ParameterLocation.Path;
                    keyParameter.Schema = new OpenApiSchema { Type = "integer", Format = "int32" };
                }
            }
        }
    }
}
