namespace Pandora.Data.Models
{
    public class ObjectDefinition
    {
        public ObjectType Type { get; set; }

        public string? ReferenceName { get; set; }

        public ObjectDefinition? NestedItem { get; set; }

        // Minimum is the minimum number of items which must be specified when this is a Dictionary/List element, if specified
        public int? Minimum { get; set; }

        // Maximum is the maximum number of items which must be specified when this is a Dictionary/List element, if specified
        public int? Maximum { get; set; }

        // UniqueItems specifies whether every item in this List/Dictionary must be unique
        public bool? UniqueItems { get; set; }
    }
}