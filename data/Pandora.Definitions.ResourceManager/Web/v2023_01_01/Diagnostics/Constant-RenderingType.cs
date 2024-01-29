// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.Diagnostics;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RenderingTypeConstant
{
    [Description("AppInsight")]
    AppInsight,

    [Description("AppInsightEnablement")]
    AppInsightEnablement,

    [Description("Card")]
    Card,

    [Description("ChangeAnalysisOnboarding")]
    ChangeAnalysisOnboarding,

    [Description("ChangeSets")]
    ChangeSets,

    [Description("ChangesView")]
    ChangesView,

    [Description("DataSummary")]
    DataSummary,

    [Description("DependencyGraph")]
    DependencyGraph,

    [Description("Detector")]
    Detector,

    [Description("DownTime")]
    DownTime,

    [Description("DropDown")]
    DropDown,

    [Description("DynamicInsight")]
    DynamicInsight,

    [Description("Email")]
    Email,

    [Description("Form")]
    Form,

    [Description("Guage")]
    Guage,

    [Description("Insights")]
    Insights,

    [Description("Markdown")]
    Markdown,

    [Description("NoGraph")]
    NoGraph,

    [Description("PieChart")]
    PieChart,

    [Description("SearchComponent")]
    SearchComponent,

    [Description("Solution")]
    Solution,

    [Description("SummaryCard")]
    SummaryCard,

    [Description("Table")]
    Table,

    [Description("TimeSeries")]
    TimeSeries,

    [Description("TimeSeriesPerInstance")]
    TimeSeriesPerInstance,
}
