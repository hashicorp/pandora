using System.Linq;
using Pandora.Data.Models;

namespace Pandora.Data.Transformers
{
    public static class TerraformSchemaTest
    {
        public static TerraformSchemaTestDefinition Map(Definitions.Interfaces.TerraformSchemaTestDefinition input)
        {
            // TODO: tests
            var steps = input.Steps.Select(TestDataDefinition.Map).ToList();
            return new TerraformSchemaTestDefinition
            {
                Name = input.Name,
                Steps = steps,
            };
        }
    }
}