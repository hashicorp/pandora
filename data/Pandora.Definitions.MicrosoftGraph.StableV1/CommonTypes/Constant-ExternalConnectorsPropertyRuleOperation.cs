// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExternalConnectorsPropertyRuleOperationConstant
{
    [Description("Null")]
    @null,

    [Description("Equals")]
    @equals,

    [Description("NotEquals")]
    @notEquals,

    [Description("Contains")]
    @contains,

    [Description("NotContains")]
    @notContains,

    [Description("LessThan")]
    @lessThan,

    [Description("GreaterThan")]
    @greaterThan,

    [Description("StartsWith")]
    @startsWith,
}
