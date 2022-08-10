using System.Collections.Generic;

namespace Pandora.Data.Models;

public class TerraformSchemaModelDefinition
{
    public Dictionary<string, TerraformSchemaFieldDefinition> Fields { get; set; }
}