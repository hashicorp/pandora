// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_04_01.NetworkInterfaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualNetworkPrivateLinkServiceNetworkPoliciesConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
