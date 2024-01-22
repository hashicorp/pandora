// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.ActionRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ActionRuleStatusConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
