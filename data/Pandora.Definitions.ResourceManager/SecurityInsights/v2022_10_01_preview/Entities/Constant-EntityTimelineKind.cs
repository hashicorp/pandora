// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.Entities;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EntityTimelineKindConstant
{
    [Description("Activity")]
    Activity,

    [Description("Anomaly")]
    Anomaly,

    [Description("Bookmark")]
    Bookmark,

    [Description("SecurityAlert")]
    SecurityAlert,
}
