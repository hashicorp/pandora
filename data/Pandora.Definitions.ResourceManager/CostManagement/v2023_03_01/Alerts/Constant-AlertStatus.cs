// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_03_01.Alerts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertStatusConstant
{
    [Description("Active")]
    Active,

    [Description("Dismissed")]
    Dismissed,

    [Description("None")]
    None,

    [Description("Overridden")]
    Overridden,

    [Description("Resolved")]
    Resolved,
}
