using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.BackupResourceStorageConfigsNonCRR;

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
