using System.Linq;
using TerraformSchemaDefinition = Pandora.Data.Models.TerraformSchemaDefinition;

namespace Pandora.Data.Transformers
{
    public static class SchemaDefinition
    {
        public static TerraformSchemaDefinition Map(Definitions.Interfaces.TerraformSchemaDefinition input)
        {
            var schemaProperties = input.GetType().GetProperties().ToList();
            
            var constants = Constant.FromObject(input.GetType()).Distinct(new ConstantComparer()).OrderBy(c => c.Name).ToList();
            var fields = schemaProperties.Select(SchemaFieldDefinition.Map).Distinct(new SchemaFieldComparer()).OrderBy(f =>f.Name).ToList();
            var models = SchemaModelDefinition.Map(input.GetType()).Distinct(new SchemaModelComparer()).OrderBy(m =>m.Name).ToList();
            
            return new TerraformSchemaDefinition
            {
                Constants = constants,
                Fields = fields,
                Models = models,
            };
        }
    }
}