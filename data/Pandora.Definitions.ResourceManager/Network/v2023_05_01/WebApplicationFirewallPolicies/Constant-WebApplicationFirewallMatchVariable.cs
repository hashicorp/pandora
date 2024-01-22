// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_05_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WebApplicationFirewallMatchVariableConstant
{
    [Description("PostArgs")]
    PostArgs,

    [Description("QueryString")]
    QueryString,

    [Description("RemoteAddr")]
    RemoteAddr,

    [Description("RequestBody")]
    RequestBody,

    [Description("RequestCookies")]
    RequestCookies,

    [Description("RequestHeaders")]
    RequestHeaders,

    [Description("RequestMethod")]
    RequestMethod,

    [Description("RequestUri")]
    RequestUri,
}
