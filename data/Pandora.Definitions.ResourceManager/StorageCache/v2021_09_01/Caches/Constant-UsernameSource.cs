using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageCache.v2021_09_01.Caches;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UsernameSourceConstant
{
    [Description("AD")]
    AD,

    [Description("File")]
    File,

    [Description("LDAP")]
    LDAP,

    [Description("None")]
    None,
}
