using System.ComponentModel;

namespace Pandora.Data.Models
{
    public class OptionDefinition
    {
        public string Name { get; set; }
        
        public OptionDefinitionType Type { get; set; }
        
        // NOTE: whilst in properties it makes sense to differentiate between Required and Optional
        // (since they can be read-only) in Settings these are binary - so these can be represented
        // as a single field. 
        public bool Required { get; set; }
     
        public string QueryStringName { get; set; }
    }

    public enum OptionDefinitionType
    {
        Unknown,
        
        [Description("boolean")]
        Boolean,
        
        [Description("integer")]
        Integer,
        
        [Description("string")]
        String,
    }
}