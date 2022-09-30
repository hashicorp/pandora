namespace Pandora.Data.Models;

public class TerraformFieldMappingDefinition
{
    /// <summary>
    /// Type defines which kind of Field Mapping Definition this is, for example DirectAssignment.
    /// </summary>
    public TerraformFieldMappingType Type { get; set; }

    /// <summary>
    /// DirectAssignment defines information for this Mapping when Type is set to DirectAssignment.
    /// </summary>
    public TerraformFieldMappingDirectAssignmentDefinition? DirectAssignment { get; set; }

    /// <summary>
    /// ModelToModel defines information for this Mapping when Type is set to ModelToModel.
    /// </summary>
    public TerraformFieldMappingModelToModelDefinition? ModelToModel { get; set; }

    /// <summary>
    /// Manual defines information for this Mapping when Type is set to Manual.
    /// </summary>
    public TerraformFieldMappingManualDefinition? Manual { get; set; }
}