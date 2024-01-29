// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_06_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGatewaySkuNameConstant
{
    [Description("Basic")]
    Basic,

    [Description("Standard_Large")]
    StandardLarge,

    [Description("Standard_Medium")]
    StandardMedium,

    [Description("Standard_Small")]
    StandardSmall,

    [Description("Standard_v2")]
    StandardVTwo,

    [Description("WAF_Large")]
    WAFLarge,

    [Description("WAF_Medium")]
    WAFMedium,

    [Description("WAF_v2")]
    WAFVTwo,
}
