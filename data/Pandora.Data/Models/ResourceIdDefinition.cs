using System.Collections.Generic;

namespace Pandora.Data.Models;

public class ResourceIdDefinition
{
    public string Name { get; set; }

    public string? CommonAlias { get; set; }

    public string IdString { get; set; }

    public List<ConstantDefinition> Constants { get; set; }

    public List<ResourceIdSegmentDefinition> Segments { get; set; }
}