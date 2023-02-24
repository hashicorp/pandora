using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2022_11_01.Vaults;

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

    [Description("getrotationpolicy")]
    Getrotationpolicy,

    [Description("import")]
    Import,

    [Description("list")]
    List,

    [Description("purge")]
    Purge,

    [Description("recover")]
    Recover,

    [Description("release")]
    Release,

    [Description("restore")]
    Restore,

    [Description("rotate")]
    Rotate,

    [Description("setrotationpolicy")]
    Setrotationpolicy,

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
