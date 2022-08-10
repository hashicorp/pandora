using System;
using System.Reflection;
using Pandora.Data.Helpers;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;

namespace Pandora.Data.Transformers;

public static class TerraformSchemaFieldDefinition
{
    public static Models.TerraformSchemaFieldDefinition Map(PropertyInfo input)
    {
        if (!input.HasAttribute<HclNameAttribute>())
        {
            throw new NotSupportedException("Property must have the [HclName] attribute");
        }

        var hclAttribute = input.GetCustomAttribute<HclNameAttribute>();
        var objectDefinition = TerraformSchemaObjectDefinition.Map(input.PropertyType);
        var definition = new Models.TerraformSchemaFieldDefinition
        {
            Name = input.Name,
            HclName = hclAttribute.Name,
            Computed = input.HasAttribute<ComputedAttribute>(),
            ForceNew = input.HasAttribute<ForceNewAttribute>(),
            Optional = input.HasAttribute<OptionalAttribute>(),
            Required = input.HasAttribute<RequiredAttribute>(),
            Mappings = new TerraformSchemaMappingDefinition
            {
                // TODO: implement mappings
                Create = null,
                Read = null,
                Update = null,
                ResourceIDSegment = null,
            },
            ObjectDefinition = objectDefinition,
            Documentation = new TerraformSchemaDocumentationDefinition(),
        };
        if (!definition.Computed && !definition.Optional && !definition.Required)
        {
            throw new NotSupportedException("One of the `Computed`, `Optional` or `Required` attributes must be present");
        }

        if (input.HasAttribute<DocumentationAttribute>())
        {
            var documentationAttribute = input.GetCustomAttribute<DocumentationAttribute>();
            definition.Documentation.Markdown = documentationAttribute.Markdown;
        }
        
        return definition;
    }
}