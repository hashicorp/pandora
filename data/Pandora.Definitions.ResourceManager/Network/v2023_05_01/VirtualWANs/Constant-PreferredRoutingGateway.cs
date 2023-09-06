using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_05_01.VirtualWANs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PreferredRoutingGatewayConstant
{
    [Description("ExpressRoute")]
    ExpressRoute,

    [Description("None")]
    None,

    [Description("VpnGateway")]
    VpnGateway,
}
