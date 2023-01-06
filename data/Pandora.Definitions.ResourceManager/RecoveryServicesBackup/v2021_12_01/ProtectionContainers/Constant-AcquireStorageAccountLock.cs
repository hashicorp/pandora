using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.ProtectionContainers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AcquireStorageAccountLockConstant
{
    [Description("Acquire")]
    Acquire,

    [Description("NotAcquire")]
    NotAcquire,
}
