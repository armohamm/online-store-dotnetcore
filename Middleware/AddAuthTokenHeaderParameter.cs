using System.Collections.Generic;
using Swashbuckle.Swagger.Model;
using Swashbuckle.SwaggerGen.Generator;

namespace project.Middleware
{
    public class AddAuthTokenHeaderParameter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();

            operation.Parameters.Add(new HeaderParameter()
            {
                Name = "accessToken",
                In = "header",
                Type = "string",
                Required = false
            });

        }
    }

    class HeaderParameter : NonBodyParameter
    {

    }
}