// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsFirewallRuleProfileTypesConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("Domain")]
    @domain,

    [Description("Private")]
    @private,

    [Description("Public")]
    @public,
}
