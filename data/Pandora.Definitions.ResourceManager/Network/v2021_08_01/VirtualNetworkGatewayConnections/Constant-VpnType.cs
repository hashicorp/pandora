using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.VirtualNetworkGatewayConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VpnTypeConstant
{
    [Description("PolicyBased")]
    PolicyBased,

    [Description("RouteBased")]
    RouteBased,
}
