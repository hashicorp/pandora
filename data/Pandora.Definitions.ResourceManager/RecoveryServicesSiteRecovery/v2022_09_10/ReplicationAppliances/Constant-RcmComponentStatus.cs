using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationAppliances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RcmComponentStatusConstant
{
    [Description("Critical")]
    Critical,

    [Description("Healthy")]
    Healthy,

    [Description("Unknown")]
    Unknown,

    [Description("Warning")]
    Warning,
}
