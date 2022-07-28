using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.Network;

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
