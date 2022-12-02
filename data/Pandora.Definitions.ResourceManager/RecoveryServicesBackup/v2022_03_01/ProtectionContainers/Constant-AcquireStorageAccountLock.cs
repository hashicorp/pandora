using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.ProtectionContainers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AcquireStorageAccountLockConstant
{
    [Description("Acquire")]
    Acquire,

    [Description("NotAcquire")]
    NotAcquire,
}
