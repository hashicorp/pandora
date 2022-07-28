using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.LoadBalancers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LoadBalancerOutboundRuleProtocolConstant
{
    [Description("All")]
    All,

    [Description("Tcp")]
    Tcp,

    [Description("Udp")]
    Udp,
}
