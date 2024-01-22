// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_11_01.SourceControls;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ContentTypeConstant
{
    [Description("AnalyticRule")]
    AnalyticRule,

    [Description("AutomationRule")]
    AutomationRule,

    [Description("HuntingQuery")]
    HuntingQuery,

    [Description("Parser")]
    Parser,

    [Description("Playbook")]
    Playbook,

    [Description("Workbook")]
    Workbook,
}
