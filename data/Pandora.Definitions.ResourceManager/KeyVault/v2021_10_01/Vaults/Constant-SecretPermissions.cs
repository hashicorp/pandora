using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2021_10_01.Vaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecretPermissionsConstant
{
    [Description("all")]
    All,

    [Description("backup")]
    Backup,

    [Description("delete")]
    Delete,

    [Description("get")]
    Get,

    [Description("list")]
    List,

    [Description("purge")]
    Purge,

    [Description("recover")]
    Recover,

    [Description("restore")]
    Restore,

    [Description("set")]
    Set,
}
