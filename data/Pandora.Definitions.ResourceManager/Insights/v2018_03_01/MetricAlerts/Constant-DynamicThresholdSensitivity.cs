// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2018_03_01.MetricAlerts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DynamicThresholdSensitivityConstant
{
    [Description("High")]
    High,

    [Description("Low")]
    Low,

    [Description("Medium")]
    Medium,
}
