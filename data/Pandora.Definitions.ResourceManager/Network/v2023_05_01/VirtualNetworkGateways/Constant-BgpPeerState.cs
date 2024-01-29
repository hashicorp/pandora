// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_05_01.VirtualNetworkGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BgpPeerStateConstant
{
    [Description("Connected")]
    Connected,

    [Description("Connecting")]
    Connecting,

    [Description("Idle")]
    Idle,

    [Description("Stopped")]
    Stopped,

    [Description("Unknown")]
    Unknown,
}
