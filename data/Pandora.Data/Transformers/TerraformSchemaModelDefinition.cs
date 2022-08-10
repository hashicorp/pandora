using System;
using System.Collections.Generic;
using Pandora.Data.Helpers;

namespace Pandora.Data.Transformers;

public static class TerraformSchemaModelDefinition
{
    public static Dictionary<string, Models.TerraformSchemaModelDefinition>? Map(Type input)
    {
        // TODO: tests
        var output = new Dictionary<string, Models.TerraformSchemaModelDefinition>();

        var fields = new Dictionary<string, Models.TerraformSchemaFieldDefinition>();
        foreach (var property in input.GetProperties())
        {
            // parse this specific field
            var fieldFromProperty = TerraformSchemaFieldDefinition.Map(property!);
            fields.Add(property.Name, fieldFromProperty);

            if (property.PropertyType.IsNativeType() || property.PropertyType.IsPandoraCustomType())
            {
                continue;
            }
            
            var nestedModels = Map(property.PropertyType);
            foreach (var model in nestedModels)
            {
                output.Add(model.Key, model.Value);
            }
        }
        output.Add(input.Name, new Models.TerraformSchemaModelDefinition
        {
            Fields = fields,
        });
        
        return output;
    }
}