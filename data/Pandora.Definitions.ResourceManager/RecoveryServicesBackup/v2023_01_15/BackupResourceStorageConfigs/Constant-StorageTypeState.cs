using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_01_15.BackupResourceStorageConfigs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageTypeStateConstant
{
    [Description("Invalid")]
    Invalid,

    [Description("Locked")]
    Locked,

    [Description("Unlocked")]
    Unlocked,
}
