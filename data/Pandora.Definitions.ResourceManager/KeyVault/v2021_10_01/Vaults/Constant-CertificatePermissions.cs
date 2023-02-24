using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2021_10_01.Vaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CertificatePermissionsConstant
{
    [Description("all")]
    All,

    [Description("backup")]
    Backup,

    [Description("create")]
    Create,

    [Description("delete")]
    Delete,

    [Description("deleteissuers")]
    Deleteissuers,

    [Description("get")]
    Get,

    [Description("getissuers")]
    Getissuers,

    [Description("import")]
    Import,

    [Description("list")]
    List,

    [Description("listissuers")]
    Listissuers,

    [Description("managecontacts")]
    Managecontacts,

    [Description("manageissuers")]
    Manageissuers,

    [Description("purge")]
    Purge,

    [Description("recover")]
    Recover,

    [Description("restore")]
    Restore,

    [Description("setissuers")]
    Setissuers,

    [Description("update")]
    Update,
}
