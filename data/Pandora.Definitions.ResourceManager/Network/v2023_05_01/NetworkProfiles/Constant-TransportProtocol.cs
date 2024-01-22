// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_05_01.NetworkProfiles;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TransportProtocolConstant
{
    [Description("All")]
    All,

    [Description("Tcp")]
    Tcp,

    [Description("Udp")]
    Udp,
}
