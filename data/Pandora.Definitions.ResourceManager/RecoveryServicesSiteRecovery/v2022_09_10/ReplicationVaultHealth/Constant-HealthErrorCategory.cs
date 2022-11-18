using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationVaultHealth;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HealthErrorCategoryConstant
{
    [Description("AgentAutoUpdateArtifactDeleted")]
    AgentAutoUpdateArtifactDeleted,

    [Description("AgentAutoUpdateInfra")]
    AgentAutoUpdateInfra,

    [Description("AgentAutoUpdateRunAsAccount")]
    AgentAutoUpdateRunAsAccount,

    [Description("AgentAutoUpdateRunAsAccountExpired")]
    AgentAutoUpdateRunAsAccountExpired,

    [Description("AgentAutoUpdateRunAsAccountExpiry")]
    AgentAutoUpdateRunAsAccountExpiry,

    [Description("Configuration")]
    Configuration,

    [Description("FabricInfrastructure")]
    FabricInfrastructure,

    [Description("None")]
    None,

    [Description("Replication")]
    Replication,

    [Description("TestFailover")]
    TestFailover,

    [Description("VersionExpiry")]
    VersionExpiry,
}
