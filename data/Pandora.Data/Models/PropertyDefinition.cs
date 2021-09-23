namespace Pandora.Data.Models
{
    public class PropertyDefinition
    {
        public string? DateFormat { get; set; }
        public object? Default { get; set; }
        public bool ForceNew { get; set; }
        public bool IsTypeHint { get; set; }
        public string JsonName { get; set; }
        public string Name { get; set; }
        public ObjectDefinition ObjectDefinition { get; set; }
        public bool Optional { get; set; }
        public bool Required { get; set; }
        public ValidationDefinition? Validation { get; set; }
    }
}