using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationRecoveryPlans;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RpInMageRecoveryPointTypeConstant
{
    [Description("Custom")]
    Custom,

    [Description("LatestTag")]
    LatestTag,

    [Description("LatestTime")]
    LatestTime,
}
