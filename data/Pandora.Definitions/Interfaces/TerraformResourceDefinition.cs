using System.Collections.Generic;

namespace Pandora.Definitions.Interfaces
{
    public enum TerraformResourceType
    {
        // here to catch unintentional bugs
        Unknown,
        
        Resource,
        DataSource
    }
    
    public interface TerraformResourceDefinition
    {
        public string ResourceName { get; }
        
        public TerraformResourceType ResourceType { get; }
        
        public bool Generate { get; }
        
        public ApiDefinition Api { get; }
        
        public IEnumerable<TerraformFunctionDefinition> Functions { get; }
        
        // List since the ordering matters
        public List<SchemaToResourceIdMapping> SchemaToResourceIdMappings { get; }
        
        public ResourceID ResourceId { get; }
        
        public TerraformSchemaDefinition Schema { get; }

        public List<TerraformSchemaTestDefinition> Tests { get; }
    }
}