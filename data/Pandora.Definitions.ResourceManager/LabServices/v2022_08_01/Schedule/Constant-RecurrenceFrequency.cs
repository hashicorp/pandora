// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.LabServices.v2022_08_01.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecurrenceFrequencyConstant
{
    [Description("Daily")]
    Daily,

    [Description("Weekly")]
    Weekly,
}
