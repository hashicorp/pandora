// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_04_01.FirewallPolicyRuleCollectionGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FirewallPolicyRuleNetworkProtocolConstant
{
    [Description("Any")]
    Any,

    [Description("ICMP")]
    ICMP,

    [Description("TCP")]
    TCP,

    [Description("UDP")]
    UDP,
}
