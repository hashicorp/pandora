// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Win32LobAppPowerShellScriptRuleOperatorConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("Equal")]
    @equal,

    [Description("NotEqual")]
    @notEqual,

    [Description("GreaterThan")]
    @greaterThan,

    [Description("GreaterThanOrEqual")]
    @greaterThanOrEqual,

    [Description("LessThan")]
    @lessThan,

    [Description("LessThanOrEqual")]
    @lessThanOrEqual,
}
