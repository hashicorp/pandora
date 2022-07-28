using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.Network;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HubRoutingPreferenceConstant
{
    [Description("ASPath")]
    ASPath,

    [Description("ExpressRoute")]
    ExpressRoute,

    [Description("VpnGateway")]
    VpnGateway,
}
