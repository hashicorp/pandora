using System.Collections.Generic;

namespace Pandora.Definitions.Interfaces
{
    public interface TerraformSchemaTestDefinition
    {
        string Name { get; }

        List<TerraformSchemaTestData> Steps { get; }
    }
}