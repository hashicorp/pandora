// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_05_01.FirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.Integer)]
internal enum FirewallPolicyIDPSSignatureModeConstant
{
    [Description("1")]
    One,

    [Description("2")]
    Two,

    [Description("0")]
    Zero,
}
