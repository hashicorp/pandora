namespace Pandora.Definitions.Mappings;

/// <summary>
/// MappingDefinition is an intermediate model used to define a mapping between a Field within
/// an Schema Model and a Field within an SDK Model.
/// </summary>
public class MappingDefinition
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

    /// <summary>
    /// Direct specifies that this is a Direct Assignment Mapping.
    /// </summary>
    /// <returns>A DirectAssignmentMapping</returns>
    public DirectAssignmentMapping Direct()
    {
        return new DirectAssignmentMapping
        {
            FromSchemaModelName = FromSchemaModelName,
            FromSchemaPath = FromSchemaPath,
            ToSdkModelName = ToSdkModelName,
            ToSdkFieldPath = ToSdkFieldPath,
        };
    }
}
