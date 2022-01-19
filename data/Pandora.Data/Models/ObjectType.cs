namespace Pandora.Data.Models;

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
    SystemAndUserAssignedIdentityList,
    SystemAndUserAssignedIdentityMap,
    SystemOrUserAssignedIdentityList,
    SystemOrUserAssignedIdentityMap,
    UserAssignedIdentityList,
    UserAssignedIdentityMap,
    Tags,
}