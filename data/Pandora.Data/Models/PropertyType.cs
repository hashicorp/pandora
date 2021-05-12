using System.ComponentModel;

namespace Pandora.Data.Models
{
    public enum PropertyType
    {
        // TODO: we should probably have `RawObject` too (`interface{}` in Go)
        // and also Dictionary[string]object (e.g. AKS)
        // presumably the generator would output interfaces/structs and a parser
        // which iterated over it until we found one that's valid
        // but we can ignore that for now until we need it 
        
        // intentionally exists just to catch instances where this is undefined
        Unknown,
        
        [Description("boolean")]
        Boolean,
        
        [Description("constant")]
        Constant,
        
        [Description("datetime")]
        DateTime,
        
        [Description("integer")]
        Integer,
         
        [Description("list")]
        List,
        
        [Description("location")]
        Location,
        
        [Description("object")]
        Object,
        
        [Description("tags")]
        Tags,
        
        [Description("string")]
        String,
    }
}