// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceComplianceScriptRuleOperatorConstant
{
    [Description("None")]
    @none,

    [Description("And")]
    @and,

    [Description("Or")]
    @or,

    [Description("IsEquals")]
    @isEquals,

    [Description("NotEquals")]
    @notEquals,

    [Description("GreaterThan")]
    @greaterThan,

    [Description("LessThan")]
    @lessThan,

    [Description("Between")]
    @between,

    [Description("NotBetween")]
    @notBetween,

    [Description("GreaterEquals")]
    @greaterEquals,

    [Description("LessEquals")]
    @lessEquals,

    [Description("DayTimeBetween")]
    @dayTimeBetween,

    [Description("BeginsWith")]
    @beginsWith,

    [Description("NotBeginsWith")]
    @notBeginsWith,

    [Description("EndsWith")]
    @endsWith,

    [Description("NotEndsWith")]
    @notEndsWith,

    [Description("Contains")]
    @contains,

    [Description("NotContains")]
    @notContains,

    [Description("AllOf")]
    @allOf,

    [Description("OneOf")]
    @oneOf,

    [Description("NoneOf")]
    @noneOf,

    [Description("SetEquals")]
    @setEquals,

    [Description("OrderedSetEquals")]
    @orderedSetEquals,

    [Description("SubsetOf")]
    @subsetOf,

    [Description("ExcludesAll")]
    @excludesAll,
}
