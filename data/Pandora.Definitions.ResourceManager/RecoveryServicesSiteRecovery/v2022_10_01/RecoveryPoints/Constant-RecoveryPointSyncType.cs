using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.RecoveryPoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecoveryPointSyncTypeConstant
{
    [Description("MultiVmSyncRecoveryPoint")]
    MultiVmSyncRecoveryPoint,

    [Description("PerVmRecoveryPoint")]
    PerVmRecoveryPoint,
}
