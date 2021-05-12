using System.Collections.Generic;

namespace Pandora.Data.Models
{
    public class TerraformResourceDefinition
    {
        public ApiDefinition ApiDefinition { get; set; }
        public bool IsDataSource { get; set; }
        public bool Generate { get; set; }
        public string Name { get; set; }
        public ResourceIdDefinition ResourceId { get; set; }
        public string ResourceLabel { get; set; }
        
        public List<TerraformFunctionDefinition> Functions { get; set; }
        public TerraformSchemaDefinition Schema { get; set; }
        public List<TerraformSchemaTestDefinition> Tests { get; set; }
        
        // TODO: populate
        public SchemaToResourceIdMapping SchemaToResourceIdMapping { get; set; }
    }
}