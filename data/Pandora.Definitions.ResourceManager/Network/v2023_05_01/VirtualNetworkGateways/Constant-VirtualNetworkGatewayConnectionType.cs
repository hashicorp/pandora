// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_05_01.VirtualNetworkGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualNetworkGatewayConnectionTypeConstant
{
    [Description("ExpressRoute")]
    ExpressRoute,

    [Description("IPsec")]
    IPsec,

    [Description("VPNClient")]
    VPNClient,

    [Description("Vnet2Vnet")]
    VnetTwoVnet,
}
