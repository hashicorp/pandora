namespace Pandora.Definitions.Interfaces
{
    public class SchemaToResourceIdMapping
    {
        // SchemaField says that this value should be sourced from the Schema field at this index
        public string? SchemaField { get; private set; }
        
        // SpecialField defines the special field that this value should be sourced (e.g. Subscription ID which is a global field)
        public SpecialFieldType? SpecialField { get; private set; }
        
        // IdField defines the field within the ResourceID where this should be mapped too
        public string IdField { get; private set; }

        public SchemaToResourceIdMapping(string idField, SpecialFieldType specialFieldType)
        {
            IdField = idField;
            SpecialField = specialFieldType;
        }

        // TODO: we could use an expression instead here
        public SchemaToResourceIdMapping(string idField, string schemaField)
        {
            IdField = idField;
            SchemaField = schemaField;
        }
    }
}