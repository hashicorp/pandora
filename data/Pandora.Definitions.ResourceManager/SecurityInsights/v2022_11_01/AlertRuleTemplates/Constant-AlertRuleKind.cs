// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_11_01.AlertRuleTemplates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertRuleKindConstant
{
    [Description("Fusion")]
    Fusion,

    [Description("MicrosoftSecurityIncidentCreation")]
    MicrosoftSecurityIncidentCreation,

    [Description("Scheduled")]
    Scheduled,
}
