using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualNetworkGatewayConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualNetworkGatewayConnectionTypeConstant
{
    [Description("ExpressRoute")]
    ExpressRoute,

    [Description("IPsec")]
    IPsec,

    [Description("VPNClient")]
    VPNClient,

    [Description("Vnet2Vnet")]
    VnetTwoVnet,
}
