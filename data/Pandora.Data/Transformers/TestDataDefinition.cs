using System.Collections.Generic;
using Pandora.Data.Models;

namespace Pandora.Data.Transformers
{
    public static class TestDataDefinition
    {
        public static TerraformTestDataDefinition Map(Definitions.Interfaces.TerraformSchemaTestData input)
        {
            // TODO: tests
            return new TerraformTestDataDefinition
            {
                ImportAfterApply = input.ImportAfterApply,
                FieldsUnavailableAtImport = input.FieldUnavailableAtImport ?? new List<string>(),
                TestConfigurationHcl = input.TestConfiguration,
            };
        }
    }
}