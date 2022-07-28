using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.DdosCustomPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DdosCustomPolicyTriggerSensitivityOverrideConstant
{
    [Description("Default")]
    Default,

    [Description("High")]
    High,

    [Description("Low")]
    Low,

    [Description("Relaxed")]
    Relaxed,
}
