// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2022_06_01.DataCollectionRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KnownPerfCounterDataSourceStreamsConstant
{
    [Description("Microsoft-InsightsMetrics")]
    MicrosoftNegativeInsightsMetrics,

    [Description("Microsoft-Perf")]
    MicrosoftNegativePerf,
}
