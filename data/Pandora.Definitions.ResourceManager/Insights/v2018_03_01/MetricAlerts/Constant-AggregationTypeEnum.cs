using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2018_03_01.MetricAlerts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AggregationTypeEnumConstant
{
    [Description("Average")]
    Average,

    [Description("Count")]
    Count,

    [Description("Maximum")]
    Maximum,

    [Description("Minimum")]
    Minimum,

    [Description("Total")]
    Total,
}
