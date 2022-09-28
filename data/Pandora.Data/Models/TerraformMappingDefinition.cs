using System.Collections.Generic;

namespace Pandora.Data.Models;

public class TerraformMappingDefinition
{
    /// <summary>
    /// Create is a list of Field Mapping Definitions, defining how Fields (and nested Models) within the Schema
    /// gets mapped to/from SDK Models and Fields during Creation.
    /// </summary>
    public List<TerraformFieldMappingDefinition> Create { get; set; }

    /// <summary>
    /// Update is a list of Field Mapping Definitions, defining how Fields (and nested Models) within the Schema
    /// gets mapped to/from SDK Models and Fields during Updates.
    /// </summary>
    public List<TerraformFieldMappingDefinition>? Update { get; set; }

    /// <summary>
    /// Read is a list of Field Mapping Definitions, defining how Fields (and nested Models) within the Schema
    /// gets mapped to/from SDK Models and Fields during Reads.
    /// </summary>
    public List<TerraformFieldMappingDefinition> Read { get; set; }

    /// <summary>
    /// ResourceIds is a list of Resource ID Mapping Definitions, defining how a top-level Schema Field
    /// gets mapped to/from a Resource ID Segment.
    /// </summary>
    public List<TerraformResourceIDMappingDefinition> ResourceIds { get; set; }
}