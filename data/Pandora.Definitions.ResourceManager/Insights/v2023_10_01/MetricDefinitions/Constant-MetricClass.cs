using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2023_10_01.MetricDefinitions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MetricClassConstant
{
    [Description("Availability")]
    Availability,

    [Description("Errors")]
    Errors,

    [Description("Latency")]
    Latency,

    [Description("Saturation")]
    Saturation,

    [Description("Transactions")]
    Transactions,
}
