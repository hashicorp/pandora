using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_04_01.CloudServicePublicIPAddresses;

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
