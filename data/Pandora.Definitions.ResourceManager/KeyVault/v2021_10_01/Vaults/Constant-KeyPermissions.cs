using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2021_10_01.Vaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KeyPermissionsConstant
{
    [Description("all")]
    All,

    [Description("backup")]
    Backup,

    [Description("create")]
    Create,

    [Description("decrypt")]
    Decrypt,

    [Description("delete")]
    Delete,

    [Description("encrypt")]
    Encrypt,

    [Description("get")]
    Get,

    [Description("import")]
    Import,

    [Description("list")]
    List,

    [Description("purge")]
    Purge,

    [Description("recover")]
    Recover,

    [Description("restore")]
    Restore,

    [Description("sign")]
    Sign,

    [Description("unwrapKey")]
    UnwrapKey,

    [Description("update")]
    Update,

    [Description("verify")]
    Verify,

    [Description("wrapKey")]
    WrapKey,
}
