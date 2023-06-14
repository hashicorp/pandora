using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.NetworkInterfaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EffectiveRouteSourceConstant
{
    [Description("Default")]
    Default,

    [Description("Unknown")]
    Unknown,

    [Description("User")]
    User,

    [Description("VirtualNetworkGateway")]
    VirtualNetworkGateway,
}
