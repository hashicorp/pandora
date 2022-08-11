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

    public override bool Equals(object? obj)
    {
        if (obj is not TerraformSchemaFieldDefinition)
        {
            return false;
        }

        var other = (TerraformSchemaFieldDefinition)obj;
        if (Computed != other.Computed)
        {
            return false;
        }
        if (ForceNew != other.ForceNew)
        {
            return false;
        }
        if (HclName != other.HclName)
        {
            return false;
        }
        if (Name != other.Name)
        {
            return false;
        }
        if (Optional != other.Optional)
        {
            return false;
        }
        if (Required != other.Required)
        {
            return false;
        }

        // TODO: Documentation Mappings ObjectDefinition Validation
        return true;
    }
}