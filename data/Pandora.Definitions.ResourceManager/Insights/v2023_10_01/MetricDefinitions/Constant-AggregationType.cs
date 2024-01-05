using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2023_10_01.MetricDefinitions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AggregationTypeConstant
{
    [Description("Average")]
    Average,

    [Description("Count")]
    Count,

    [Description("Maximum")]
    Maximum,

    [Description("Minimum")]
    Minimum,

    [Description("None")]
    None,

    [Description("Total")]
    Total,
}
