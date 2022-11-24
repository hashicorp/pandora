using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationFabrics;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AgentVersionStatusConstant
{
    [Description("Deprecated")]
    Deprecated,

    [Description("NotSupported")]
    NotSupported,

    [Description("SecurityUpdateRequired")]
    SecurityUpdateRequired,

    [Description("Supported")]
    Supported,

    [Description("UpdateRequired")]
    UpdateRequired,
}
