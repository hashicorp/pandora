using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2021_04_01.DataCollectionRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KnownDataFlowStreamsConstant
{
    [Description("Microsoft-Event")]
    MicrosoftNegativeEvent,

    [Description("Microsoft-InsightsMetrics")]
    MicrosoftNegativeInsightsMetrics,

    [Description("Microsoft-Perf")]
    MicrosoftNegativePerf,

    [Description("Microsoft-Syslog")]
    MicrosoftNegativeSyslog,

    [Description("Microsoft-WindowsEvent")]
    MicrosoftNegativeWindowsEvent,
}
