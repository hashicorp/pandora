using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_02_01.RecoveryPoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecoveryPointSyncTypeConstant
{
    [Description("MultiVmSyncRecoveryPoint")]
    MultiVMSyncRecoveryPoint,

    [Description("PerVmRecoveryPoint")]
    PerVMRecoveryPoint,
}
