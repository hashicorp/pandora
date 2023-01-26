using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.FirewallPolicyRuleCollectionGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FirewallPolicyRuleNetworkProtocolConstant
{
    [Description("Any")]
    Any,

    [Description("ICMP")]
    ICMP,

    [Description("TCP")]
    TCP,

    [Description("UDP")]
    UDP,
}
