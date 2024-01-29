// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.Budgets;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ThresholdTypeConstant
{
    [Description("Actual")]
    Actual,

    [Description("Forecasted")]
    Forecasted,
}
