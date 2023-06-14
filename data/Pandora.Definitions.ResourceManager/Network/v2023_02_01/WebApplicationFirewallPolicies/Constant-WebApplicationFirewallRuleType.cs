using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WebApplicationFirewallRuleTypeConstant
{
    [Description("Invalid")]
    Invalid,

    [Description("MatchRule")]
    MatchRule,

    [Description("RateLimitRule")]
    RateLimitRule,
}
