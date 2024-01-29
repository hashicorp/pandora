// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.Schedules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScheduledFrequencyConstant
{
    [Description("Daily")]
    Daily,
}
