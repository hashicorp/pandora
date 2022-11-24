using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationRecoveryPlans;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecoveryPlanGroupTypeConstant
{
    [Description("Boot")]
    Boot,

    [Description("Failover")]
    Failover,

    [Description("Shutdown")]
    Shutdown,
}
