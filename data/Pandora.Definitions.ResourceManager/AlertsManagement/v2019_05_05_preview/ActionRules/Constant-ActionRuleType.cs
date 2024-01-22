// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.ActionRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ActionRuleTypeConstant
{
    [Description("ActionGroup")]
    ActionGroup,

    [Description("Diagnostics")]
    Diagnostics,

    [Description("Suppression")]
    Suppression,
}
