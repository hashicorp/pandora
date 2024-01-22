// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2016_03_01.AlertRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConditionOperatorConstant
{
    [Description("GreaterThan")]
    GreaterThan,

    [Description("GreaterThanOrEqual")]
    GreaterThanOrEqual,

    [Description("LessThan")]
    LessThan,

    [Description("LessThanOrEqual")]
    LessThanOrEqual,
}
