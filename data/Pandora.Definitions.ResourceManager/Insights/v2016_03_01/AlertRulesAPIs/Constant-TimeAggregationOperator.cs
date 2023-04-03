using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2016_03_01.AlertRulesAPIs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TimeAggregationOperatorConstant
{
    [Description("Average")]
    Average,

    [Description("Last")]
    Last,

    [Description("Maximum")]
    Maximum,

    [Description("Minimum")]
    Minimum,

    [Description("Total")]
    Total,
}
