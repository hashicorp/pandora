using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationFabrics;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProtectionHealthConstant
{
    [Description("Critical")]
    Critical,

    [Description("None")]
    None,

    [Description("Normal")]
    Normal,

    [Description("Warning")]
    Warning,
}
