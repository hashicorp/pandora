namespace Pandora.Definitions.Mappings;

/// <summary>
/// A DirectAssignment mapping defines that the Schema Field specified in `FromSchemaPath` should
/// be mapped directly onto the Sdk Model Field specified in `ToSdkModelPath`.
/// 
/// DirectAssignment mappings should automatically handle converting to/from Required and Optional
/// fields as required.
/// </summary>
public class DirectAssignmentMapping : MappingType
{
    /// <summary>
    /// FromSchemaModelName is the name of the Schema Model that this mapping is From.
    /// </summary>
    public string FromSchemaModelName { get; set; }

    /// <summary>
    /// FromSchemaPath is the path to the field within the Schema Model that this mapping is From.
    /// </summary>
    public string FromSchemaPath { get; set; }

    /// <summary>
    /// ToSdkModelName is the name of the Sdk Model that this mapping is To.
    /// </summary>
    public string ToSdkModelName { get; set; }

    /// <summary>
    /// ToSdkFieldPath is the path to the field within the Sdk Model that this mapping is To.
    /// </summary>
    public string ToSdkFieldPath { get; set; }
}