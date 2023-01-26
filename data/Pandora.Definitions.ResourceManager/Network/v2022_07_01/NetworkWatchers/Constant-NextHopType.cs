using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkWatchers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NextHopTypeConstant
{
    [Description("HyperNetGateway")]
    HyperNetGateway,

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
