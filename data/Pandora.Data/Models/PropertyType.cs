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
        
        Boolean,
        Constant,
        DateTime,
        Float,
        Integer,
        List,
        Location,
        Object,
        Tags,
        String,
        UserAssignedIdentityMap,
        UserAssignedIdentityList,
        SystemAssignedIdentity,
        SystemUserAssignedIdentity,
    }
}