using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.BackupProtectableItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AzureFileShareTypeConstant
{
    [Description("Invalid")]
    Invalid,

    [Description("XSMB")]
    XSMB,

    [Description("XSync")]
    XSync,
}
