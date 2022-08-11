using System.Collections.Generic;

namespace Pandora.Data.Models;

public class TerraformResourceDefinition
{
    public string ApiVersion { get; set; }
    public TerraformMethodDefinition CreateMethod { get; set; }
    public TerraformMethodDefinition DeleteMethod { get; set; }
    public string DisplayName { get; set; }
    public bool GenerateModel { get; set; }
    public bool GenerateIDValidationFunction { get; set; }
    public bool GenerateSchema { get; set; }
    public TerraformMethodDefinition ReadMethod { get; set; }
    public string Resource { get; set; }
    public string ResourceIdName { get; set; }
    public string ResourceLabel { get; set; }
    public string ResourceName { get; set; }
    public string? SchemaModelName { get; set; }
    public Dictionary<string, TerraformSchemaModelDefinition>? SchemaModels { get; set; }

    public TerraformResourceTestDefinition Tests { get; set; }
    public TerraformMethodDefinition? UpdateMethod { get; set; }
}