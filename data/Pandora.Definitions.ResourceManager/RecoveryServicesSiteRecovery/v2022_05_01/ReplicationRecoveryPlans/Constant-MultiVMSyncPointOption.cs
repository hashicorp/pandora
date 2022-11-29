using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationRecoveryPlans;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MultiVMSyncPointOptionConstant
{
    [Description("UseMultiVmSyncRecoveryPoint")]
    UseMultiVMSyncRecoveryPoint,

    [Description("UsePerVmRecoveryPoint")]
    UsePerVMRecoveryPoint,
}
