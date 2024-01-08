using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.DscpConfiguration;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GatewayLoadBalancerTunnelProtocolConstant
{
    [Description("Native")]
    Native,

    [Description("None")]
    None,

    [Description("VXLAN")]
    VXLAN,
}
