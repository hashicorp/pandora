namespace Pandora.Data.Models
{
    public class ResourceIdSegmentDefinition
    {
        public string? ConstantReference { get; set; }
        
        public string? FixedValue { get; set; }
        
        public string Name { get; set; }
        
        public ResourceIdSegmentType Type { get; set; }
    }
}