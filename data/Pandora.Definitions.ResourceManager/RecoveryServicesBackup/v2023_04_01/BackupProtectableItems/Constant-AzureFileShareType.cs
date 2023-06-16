using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_04_01.BackupProtectableItems;

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
