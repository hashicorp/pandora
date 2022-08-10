namespace Pandora.Data.Models;

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