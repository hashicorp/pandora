using System.Collections.Generic;

namespace Pandora.Data.Models;

public class TerraformMappingDefinition
{
    /// <summary>
    /// Fields is a list of Field Mapping Definitions, defining how a top-level Schema Field gets mapped
    /// to/from an Sdk Field.
    /// </summary>
    public List<TerraformFieldMappingDefinition> Fields { get; set; }

    /// <summary>
    /// ModelToModel is a list of the Model to Model Mappings
    /// </summary>
    public List<TerraformModelToModelMappingDefinition> ModelToModel { get; set; }

    /// <summary>
    /// ResourceIds is a list of Resource ID Mapping Definitions, defining how a top-level Schema Field
    /// gets mapped to/from a Resource ID Segment.
    /// </summary>
    public List<TerraformResourceIDMappingDefinition> ResourceIds { get; set; }
}