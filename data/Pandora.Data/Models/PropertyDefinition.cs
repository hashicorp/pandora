namespace Pandora.Data.Models
{
    public class PropertyDefinition
    {
        // TODO: support for when this is a ResourceID
        // and if that ResourceID should be parse/rewritten

        public string? ConstantReference { get; set; }
        public string? DateFormat { get; set; }
        public object? Default { get; set; }
        public bool ForceNew { get; set; }
        public bool IsTypeHint { get; set; }
        public string JsonName { get; set; }
        // ListElementType defines the inner type used for Lists
        // which is defined as when `PropertyType` is set to `List`.
        public PropertyType? ListElementType { get; set; }
        public int? MinItems { get; set; }
        public int? MaxItems { get; set; }
        public string? ModelReference { get; set; }
        public string Name { get; set; }
        public bool Optional { get; set; }
        public PropertyType PropertyType { get; set; }
        public bool Required { get; set; }
        public ValidationDefinition? Validation { get; set; }
    }
}