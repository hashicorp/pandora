using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2022_06_01.DataCollectionRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KnownPrometheusForwarderDataSourceStreamsConstant
{
    [Description("Microsoft-PrometheusMetrics")]
    MicrosoftNegativePrometheusMetrics,
}
