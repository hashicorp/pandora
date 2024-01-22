// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2022_05_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedRuleExclusionMatchVariableConstant
{
    [Description("QueryStringArgNames")]
    QueryStringArgNames,

    [Description("RequestBodyJsonArgNames")]
    RequestBodyJsonArgNames,

    [Description("RequestBodyPostArgNames")]
    RequestBodyPostArgNames,

    [Description("RequestCookieNames")]
    RequestCookieNames,

    [Description("RequestHeaderNames")]
    RequestHeaderNames,
}
