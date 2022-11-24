using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectionContainerMappings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AgentAutoUpdateStatusConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
