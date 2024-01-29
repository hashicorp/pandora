// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_11_01.IncidentBookmarks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertStatusConstant
{
    [Description("Dismissed")]
    Dismissed,

    [Description("InProgress")]
    InProgress,

    [Description("New")]
    New,

    [Description("Resolved")]
    Resolved,

    [Description("Unknown")]
    Unknown,
}
