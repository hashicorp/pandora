using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_04_01.BackupStatus;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AcquireStorageAccountLockConstant
{
    [Description("Acquire")]
    Acquire,

    [Description("NotAcquire")]
    NotAcquire,
}
