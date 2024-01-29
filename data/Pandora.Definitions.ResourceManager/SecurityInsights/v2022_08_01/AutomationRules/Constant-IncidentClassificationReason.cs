// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_08_01.AutomationRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IncidentClassificationReasonConstant
{
    [Description("InaccurateData")]
    InaccurateData,

    [Description("IncorrectAlertLogic")]
    IncorrectAlertLogic,

    [Description("SuspiciousActivity")]
    SuspiciousActivity,

    [Description("SuspiciousButExpected")]
    SuspiciousButExpected,
}
