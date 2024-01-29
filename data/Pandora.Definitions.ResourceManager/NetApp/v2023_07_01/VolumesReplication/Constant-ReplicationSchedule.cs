// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2023_07_01.VolumesReplication;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicationScheduleConstant
{
    [Description("daily")]
    Daily,

    [Description("hourly")]
    Hourly,

    [Description("_10minutely")]
    OneZerominutely,
}
