// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_06_01.PeerExpressRouteCircuitConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CircuitConnectionStatusConstant
{
    [Description("Connected")]
    Connected,

    [Description("Connecting")]
    Connecting,

    [Description("Disconnected")]
    Disconnected,
}
