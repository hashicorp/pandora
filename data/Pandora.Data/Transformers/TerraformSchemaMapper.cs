using System.Linq;
using Pandora.Data.Models;

namespace Pandora.Data.Transformers
{
    public static class TerraformSchemaMapper
    {
        public static TerraformSchemaMapperDefinition? Map(Definitions.Interfaces.TerraformSchemaMapper? input)
        {
            if (input == null)
            {
                return null;
            }
            
            // TODO: tests
            var mappings = input.GetMappings().Select(Map).ToList(); 
            return new TerraformSchemaMapperDefinition
            {
                Mappings = mappings,
            };
        }

        private static TerraformSchemaMappingDefinition Map(Definitions.Interfaces.Mapping input)
        {
            return new TerraformSchemaMappingDefinition
            {
                ObjectFieldPath = input.Object.Field,
                ObjectModelName = input.Object.Model,
                SchemaFieldPath = input.Schema.Field,
                SchemaModelName = input.Schema.Model,
            };
        }
    }
}