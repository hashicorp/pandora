// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.VirtualNetworkGatewayConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualNetworkGatewayConnectionModeConstant
{
    [Description("Default")]
    Default,

    [Description("InitiatorOnly")]
    InitiatorOnly,

    [Description("ResponderOnly")]
    ResponderOnly,
}
