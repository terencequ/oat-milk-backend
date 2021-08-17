using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OatMilk.Backend.Api.AspNet {
    
    /// <summary>
    /// This schema filter will make every property 'required' for response models,
    /// for easier processing by the frontend.
    /// </summary>
    public class OatMilkSchemaFilter : ISchemaFilter
    {
        private readonly HashSet<OpenApiSchema> _valueTypes = new HashSet<OpenApiSchema>();

        public void Apply(OpenApiSchema model, SchemaFilterContext context)
        {
            if (model.Properties != null)
            {
                foreach (var prop in model.Properties) {
                    model.Required.Add(prop.Key);
                }
            }
        }
    }
}