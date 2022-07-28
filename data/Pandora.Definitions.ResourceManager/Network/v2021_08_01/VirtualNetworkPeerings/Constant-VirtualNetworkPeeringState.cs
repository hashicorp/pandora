using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.VirtualNetworkPeerings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualNetworkPeeringStateConstant
{
    [Description("Connected")]
    Connected,

    [Description("Disconnected")]
    Disconnected,

    [Description("Initiated")]
    Initiated,
}
