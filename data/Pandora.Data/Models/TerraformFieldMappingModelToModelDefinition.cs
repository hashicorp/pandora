namespace Pandora.Data.Models;

public class TerraformFieldMappingModelToModelDefinition
{
    /// <summary>
    /// SchemaModelName specifies the name of the Schema Model used for this ModelToModel Mapping.
    /// </summary>
    public string SchemaModelName { get; set; }

    /// <summary>
    /// SdkModelName specifies the name of the Sdk Model used for this ModelToModel Mapping. 
    /// </summary>
    public string SdkModelName { get; set; }

    /// <summary>
    /// SdkFieldName specifies the name of the Field within the Sdk Model
    /// </summary>
    public string SdkFieldName { get; set; }
}