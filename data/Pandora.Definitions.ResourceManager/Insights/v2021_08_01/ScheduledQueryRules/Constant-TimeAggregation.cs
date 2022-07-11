using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2021_08_01.ScheduledQueryRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TimeAggregationConstant
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
