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
    public string SchemaModelName { get; set; }
    public Dictionary<string, TerraformSchemaModelDefinition> SchemaModels { get; set; }
    public TerraformMethodDefinition? UpdateMethod { get; set; }
}

public class TerraformSchemaModelDefinition
{
    public Dictionary<string, TerraformSchemaFieldDefinition> Fields { get; set; }
}

public class TerraformSchemaFieldDefinition
{
    public bool Computed { get; set; }
    public TerraformSchemaDocumentationDefinition Documentation { get; set; }
    public bool ForceNew { get; set; }
    public string HclName { get; set; }
    public TerraformSchemaMappingDefinition Mappings { get; set; }
    public string Name { get; set; }
    public TerraformSchemaObjectDefinition ObjectDefinition { get; set; }
    public bool Optional { get; set; }
    public bool Required { get; set; }
    // public TerraformSchemaFieldValidationDefinition Validation { get; set; }
}