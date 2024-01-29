// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_08_01.ScheduledActions;

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
