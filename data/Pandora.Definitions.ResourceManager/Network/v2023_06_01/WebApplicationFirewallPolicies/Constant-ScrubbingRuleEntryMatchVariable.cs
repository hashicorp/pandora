// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_06_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScrubbingRuleEntryMatchVariableConstant
{
    [Description("RequestArgNames")]
    RequestArgNames,

    [Description("RequestCookieNames")]
    RequestCookieNames,

    [Description("RequestHeaderNames")]
    RequestHeaderNames,

    [Description("RequestIPAddress")]
    RequestIPAddress,

    [Description("RequestJSONArgNames")]
    RequestJSONArgNames,

    [Description("RequestPostArgNames")]
    RequestPostArgNames,
}
