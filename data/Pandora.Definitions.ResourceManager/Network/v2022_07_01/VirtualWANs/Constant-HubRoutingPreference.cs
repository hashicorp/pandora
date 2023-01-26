using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualWANs;

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
