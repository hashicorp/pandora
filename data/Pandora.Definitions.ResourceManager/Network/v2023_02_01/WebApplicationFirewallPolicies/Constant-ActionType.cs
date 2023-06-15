using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ActionTypeConstant
{
    [Description("Allow")]
    Allow,

    [Description("AnomalyScoring")]
    AnomalyScoring,

    [Description("Block")]
    Block,

    [Description("Log")]
    Log,
}
