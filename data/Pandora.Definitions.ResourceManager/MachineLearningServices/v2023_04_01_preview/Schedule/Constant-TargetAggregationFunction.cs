// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TargetAggregationFunctionConstant
{
    [Description("Max")]
    Max,

    [Description("Mean")]
    Mean,

    [Description("Min")]
    Min,

    [Description("None")]
    None,

    [Description("Sum")]
    Sum,
}
