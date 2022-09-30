namespace Pandora.Definitions.Mappings;

/// <summary>
/// A ModelToModel mapping defines that the Schema Model specified in `FromSchemaPath` should
/// be mapped directly onto the Sdk Model Field specified in `ToSdkModelPath`.
/// 
/// DirectAssignment mappings should automatically handle converting to/from Required and Optional
/// fields as required.
/// </summary>
public class ModelToModelMapping : MappingType
{
    /// <summary>
    /// SchemaModelName is the name of the Schema Model associated with this Mapping.
    /// </summary>
    public string SchemaModelName { get; set; }

    /// <summary>
    /// SdkModelName is the name of the Sdk Model associated with this Mapping.
    /// </summary>
    public string SdkModelName { get; set; }

    /// <summary>
    /// SdkFieldPath is the path to the field within the Sdk Model associated with this Mapping.
    /// </summary>
    public string SdkFieldPath { get; set; }
}