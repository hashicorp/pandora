namespace Pandora.Data.Models;

public class TerraformFieldMappingDirectAssignmentDefinition
{
    /// <summary>
    /// SchemaModelName specifies the name of the Schema Model used for this DirectAssignment Mapping.
    /// </summary>
    public string SchemaModelName { get; set; }

    /// <summary>
    /// SchemaFieldName specifies the name of the Field within the SchemaModel
    /// </summary>
    public string SchemaFieldName { get; set; }

    /// <summary>
    /// SdkModelName specifies the name of the Sdk Model used for this DirectAssignment Mapping. 
    /// </summary>
    public string SdkModelName { get; set; }

    /// <summary>
    /// SdkFieldName specifies the name of the Field within the Sdk Model
    /// </summary>
    public string SdkFieldName { get; set; }
}