// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.FirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FirewallPolicySkuTierConstant
{
    [Description("Basic")]
    Basic,

    [Description("Premium")]
    Premium,

    [Description("Standard")]
    Standard,
}
