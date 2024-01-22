// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2015_04_01.AutoScaleSettings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MetricStatisticTypeConstant
{
    [Description("Average")]
    Average,

    [Description("Count")]
    Count,

    [Description("Max")]
    Max,

    [Description("Min")]
    Min,

    [Description("Sum")]
    Sum,
}
