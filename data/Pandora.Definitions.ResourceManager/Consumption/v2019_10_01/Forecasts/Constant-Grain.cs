// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01.Forecasts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GrainConstant
{
    [Description("Daily")]
    Daily,

    [Description("Monthly")]
    Monthly,

    [Description("Yearly")]
    Yearly,
}
