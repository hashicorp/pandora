// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_03_01.Alerts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertTypeConstant
{
    [Description("Budget")]
    Budget,

    [Description("BudgetForecast")]
    BudgetForecast,

    [Description("Credit")]
    Credit,

    [Description("General")]
    General,

    [Description("Invoice")]
    Invoice,

    [Description("Quota")]
    Quota,

    [Description("xCloud")]
    XCloud,
}
