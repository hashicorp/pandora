using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_06_01.FirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FirewallPolicyIntrusionDetectionProfileTypeConstant
{
    [Description("Advanced")]
    Advanced,

    [Description("Basic")]
    Basic,

    [Description("Extended")]
    Extended,

    [Description("Standard")]
    Standard,
}
