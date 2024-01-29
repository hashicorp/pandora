// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_08_01.Views;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReportTimeframeTypeConstant
{
    [Description("Custom")]
    Custom,

    [Description("MonthToDate")]
    MonthToDate,

    [Description("WeekToDate")]
    WeekToDate,

    [Description("YearToDate")]
    YearToDate,
}
