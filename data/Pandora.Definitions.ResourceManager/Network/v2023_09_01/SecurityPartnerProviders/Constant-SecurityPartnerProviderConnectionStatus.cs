// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.SecurityPartnerProviders;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityPartnerProviderConnectionStatusConstant
{
    [Description("Connected")]
    Connected,

    [Description("NotConnected")]
    NotConnected,

    [Description("PartiallyConnected")]
    PartiallyConnected,

    [Description("Unknown")]
    Unknown,
}
