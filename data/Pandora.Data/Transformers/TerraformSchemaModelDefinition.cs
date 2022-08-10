using System;
using System.Collections.Generic;
using System.Linq;
using Pandora.Data.Helpers;

namespace Pandora.Data.Transformers;

public static class TerraformSchemaModelDefinition
{
    public static Dictionary<string, Models.TerraformSchemaModelDefinition>? Map(Type input)
    {
        if (input.IsAGenericDictionary())
        {
            var valueType = input.GenericDictionaryValueElement();
            return Map(valueType);
        }
        if (input.IsAGenericList())
        {
            var valueType = input.GenericListElement();
            return Map(valueType);
        }
        
        var output = new Dictionary<string, Models.TerraformSchemaModelDefinition>();

        var fields = new Dictionary<string, Models.TerraformSchemaFieldDefinition>();
        foreach (var property in input.GetProperties())
        {
            // parse this specific field
            var fieldFromProperty = TerraformSchemaFieldDefinition.Map(property);
            fields.Add(property.Name, fieldFromProperty);

            if (property.PropertyType.IsNativeType() || property.PropertyType.IsPandoraCustomType())
            {
                continue;
            }
            
            var nestedModels = Map(property.PropertyType);
            foreach (var model in nestedModels)
            {
                if (output.TryGetValue(model.Key, out var otherModel))
                {
                    // if it exists we need to validate it's the same, and skip - else raise an
                    // error we have two models with the same name and different fields since
                    // we're using models that shouldn't compile, so would indicate an import issue
                    if (otherModel.Equals(model.Value))
                    {
                        continue;
                    }

                    throw new NotSupportedException($"data error: duplicate schema model {model.Key} with different fields");
                }
                
                output.Add(model.Key, model.Value);
            }
        }

        if (fields.Count == 0)
        {
            throw new NotSupportedException($"schema model {input.Name} had no properties");
        }
        
        output.Add(input.Name, new Models.TerraformSchemaModelDefinition
        {
            Fields = fields,
        });
        
        return output;
    }
}