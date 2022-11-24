using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectedItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AgentUpgradeBlockedReasonConstant
{
    [Description("AgentNoHeartbeat")]
    AgentNoHeartbeat,

    [Description("AlreadyOnLatestVersion")]
    AlreadyOnLatestVersion,

    [Description("DistroIsNotReported")]
    DistroIsNotReported,

    [Description("DistroNotSupportedForUpgrade")]
    DistroNotSupportedForUpgrade,

    [Description("IncompatibleApplianceVersion")]
    IncompatibleApplianceVersion,

    [Description("InvalidAgentVersion")]
    InvalidAgentVersion,

    [Description("InvalidDriverVersion")]
    InvalidDriverVersion,

    [Description("MissingUpgradePath")]
    MissingUpgradePath,

    [Description("NotProtected")]
    NotProtected,

    [Description("ProcessServerNoHeartbeat")]
    ProcessServerNoHeartbeat,

    [Description("RcmProxyNoHeartbeat")]
    RcmProxyNoHeartbeat,

    [Description("RebootRequired")]
    RebootRequired,

    [Description("Unknown")]
    Unknown,

    [Description("UnsupportedProtectionScenario")]
    UnsupportedProtectionScenario,
}
