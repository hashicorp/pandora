namespace Pandora.Data.Models;

public class TerraformSchemaMappingDefinition
{
    public MappingDefinition? Create { get; set; }
    public MappingDefinition? Read { get; set; }
    public string ResourceIDSegment { get; set; }
    public MappingDefinition? Update { get; set; }
}