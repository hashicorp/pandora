using System.Reflection;
using Pandora.Data.Models;

namespace Pandora.Data.Transformers;

public static class TerraformSchemaFieldDefinition
{
    public static Models.TerraformSchemaFieldDefinition Map(PropertyInfo property)
    {
        // TODO: tests
        return new Models.TerraformSchemaFieldDefinition
        {
            Name = property.Name,
            Mappings = new TerraformSchemaMappingDefinition
            {
                Create = null,
                Read = null,
                Update = null,
                ResourceIDSegment = null,
            },
        };
    }
}