// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_06_01.VMSSPublicIPAddresses;

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
