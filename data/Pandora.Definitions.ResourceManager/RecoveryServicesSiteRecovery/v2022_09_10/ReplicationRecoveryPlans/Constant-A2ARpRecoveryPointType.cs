using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationRecoveryPlans;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum A2ARpRecoveryPointTypeConstant
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
