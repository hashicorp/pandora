namespace Pandora.Data.Models
{
    public enum ObjectType
    {
        Unknown,
        Boolean,
        Csv,
        DateTime,
        Dictionary,
        Integer,
        Float,
        List,
        RawFile,
        RawObject,
        Reference,
        String,

        // Custom Types
        Location,
        SystemAssignedIdentity,
        SystemUserAssignedIdentityList,
        SystemUserAssignedIdentityMap,
        UserAssignedIdentityList,
        UserAssignedIdentityMap,
        Tags,
    }
}