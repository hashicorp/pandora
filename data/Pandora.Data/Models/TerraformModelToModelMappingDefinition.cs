namespace Pandora.Data.Models;

public class TerraformModelToModelMappingDefinition
{
    /// <summary>
    /// SchemaModelName is the name of the Schema Model that there's a mapping between.
    /// </summary>
    public string SchemaModelName { get; set; }

    /// <summary>
    /// SdkModelName is the name of the Sdk Model that there's a mapping between.
    /// </summary>
    public string SdkModelName { get; set; }
}