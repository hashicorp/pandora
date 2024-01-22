// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.AutomationRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IncidentStatusConstant
{
    [Description("Active")]
    Active,

    [Description("Closed")]
    Closed,

    [Description("New")]
    New,
}
