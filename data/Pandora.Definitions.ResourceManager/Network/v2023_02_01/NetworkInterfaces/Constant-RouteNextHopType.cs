using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.NetworkInterfaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RouteNextHopTypeConstant
{
    [Description("Internet")]
    Internet,

    [Description("None")]
    None,

    [Description("VirtualAppliance")]
    VirtualAppliance,

    [Description("VirtualNetworkGateway")]
    VirtualNetworkGateway,

    [Description("VnetLocal")]
    VnetLocal,
}
