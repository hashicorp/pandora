// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2022_10_01.AutoScaleSettings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScaleRuleMetricDimensionOperationTypeConstant
{
    [Description("Equals")]
    Equals,

    [Description("NotEquals")]
    NotEquals,
}
