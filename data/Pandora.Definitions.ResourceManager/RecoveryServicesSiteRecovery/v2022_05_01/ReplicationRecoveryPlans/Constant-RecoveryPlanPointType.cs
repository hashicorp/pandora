using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationRecoveryPlans;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecoveryPlanPointTypeConstant
{
    [Description("Latest")]
    Latest,

    [Description("LatestApplicationConsistent")]
    LatestApplicationConsistent,

    [Description("LatestCrashConsistent")]
    LatestCrashConsistent,

    [Description("LatestProcessed")]
    LatestProcessed,
}
