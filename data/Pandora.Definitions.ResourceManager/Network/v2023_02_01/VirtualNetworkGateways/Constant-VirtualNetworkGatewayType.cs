using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.VirtualNetworkGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualNetworkGatewayTypeConstant
{
    [Description("ExpressRoute")]
    ExpressRoute,

    [Description("LocalGateway")]
    LocalGateway,

    [Description("Vpn")]
    Vpn,
}
