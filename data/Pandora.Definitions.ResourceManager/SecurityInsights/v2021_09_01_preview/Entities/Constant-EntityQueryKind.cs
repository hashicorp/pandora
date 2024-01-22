// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.Entities;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EntityQueryKindConstant
{
    [Description("Activity")]
    Activity,

    [Description("Expansion")]
    Expansion,

    [Description("Insight")]
    Insight,
}
