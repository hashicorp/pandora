namespace Pandora.Data.Models
{
    public class ObjectDefinition
    {
        public ObjectType Type { get; set; }

        public string? ReferenceName { get; set; }
        
        public ObjectDefinition? NestedItem { get; set; }
    }
}