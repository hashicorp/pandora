using System.Collections.Generic;

namespace Pandora.Data.Models
{
    public class TerraformSchemaDefinition
    {
        public List<ConstantDefinition> Constants { get; set; }
        
        public List<TerraformSchemaFieldDefinition> Fields { get; set; }
        
        public List<TerraformModelDefinition> Models { get; set; }
    }

    public class TerraformModelDefinition
    {
        public string Name { get; set; }
        
        public List<TerraformSchemaFieldDefinition> Fields { get; set; }
    }

    public class TerraformSchemaFieldDefinition
    {
        public bool CaseInsensitive { get; set; }
        public bool Computed { get; set; }
        public string? ConstantType { get; set; }
        public object? Default { get; set; }
        public TerraformFieldType FieldType { get; set; }
        public bool ForceNew { get; set; }
        public string HclLabel { get; set; }
        public int? MaxItems { get; set; }
        public int? MinItems { get; set; }
        public string? ModelType { get; set; }
        public string Name { get; set; }
        public bool Optional { get; set; }
        public bool Required { get; set; }
        
        // TODO: public ResourceIdDefinition? ResourceIdReference { get; set; }
        public ValidationDefinition? Validation { get; set; }
    }

    public enum TerraformFieldType
    {
        String,
        Integer,
        Boolean,
        Float,
        List,
        Set,
        Location,
        Tags,
    }
}