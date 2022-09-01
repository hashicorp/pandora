using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2021_04_01.DataCollectionRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KnownPerfCounterDataSourceStreamsConstant
{
    [Description("Microsoft-InsightsMetrics")]
    MicrosoftNegativeInsightsMetrics,

    [Description("Microsoft-Perf")]
    MicrosoftNegativePerf,
}
