using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2024_01_01.DisasterRecoveryConfigs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RoleDisasterRecoveryConstant
{
    [Description("Primary")]
    Primary,

    [Description("PrimaryNotReplicating")]
    PrimaryNotReplicating,

    [Description("Secondary")]
    Secondary,
}
