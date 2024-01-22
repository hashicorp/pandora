// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_06_01_preview.ScheduledActions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScheduleFrequencyConstant
{
    [Description("Daily")]
    Daily,

    [Description("Monthly")]
    Monthly,

    [Description("Weekly")]
    Weekly,
}
