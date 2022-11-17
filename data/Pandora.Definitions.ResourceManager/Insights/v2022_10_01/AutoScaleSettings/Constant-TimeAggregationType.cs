using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2022_10_01.AutoScaleSettings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TimeAggregationTypeConstant
{
    [Description("Average")]
    Average,

    [Description("Count")]
    Count,

    [Description("Last")]
    Last,

    [Description("Maximum")]
    Maximum,

    [Description("Minimum")]
    Minimum,

    [Description("Total")]
    Total,
}
