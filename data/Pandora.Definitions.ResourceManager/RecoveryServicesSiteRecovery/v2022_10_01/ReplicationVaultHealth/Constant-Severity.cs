using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationVaultHealth;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SeverityConstant
{
    [Description("Error")]
    Error,

    [Description("Info")]
    Info,

    [Description("NONE")]
    NONE,

    [Description("Warning")]
    Warning,
}
