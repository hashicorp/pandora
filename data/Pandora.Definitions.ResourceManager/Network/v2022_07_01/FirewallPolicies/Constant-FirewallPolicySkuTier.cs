using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.FirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FirewallPolicySkuTierConstant
{
    [Description("Basic")]
    Basic,

    [Description("Premium")]
    Premium,

    [Description("Standard")]
    Standard,
}
