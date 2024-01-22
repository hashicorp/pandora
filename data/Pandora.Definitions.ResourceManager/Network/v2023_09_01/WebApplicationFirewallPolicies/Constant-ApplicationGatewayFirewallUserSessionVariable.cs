// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGatewayFirewallUserSessionVariableConstant
{
    [Description("ClientAddr")]
    ClientAddr,

    [Description("GeoLocation")]
    GeoLocation,

    [Description("None")]
    None,
}
