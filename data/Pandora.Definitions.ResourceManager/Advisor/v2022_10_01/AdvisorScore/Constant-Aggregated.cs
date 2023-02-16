using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Advisor.v2022_10_01.AdvisorScore;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AggregatedConstant
{
    [Description("day")]
    Day,

    [Description("month")]
    Month,

    [Description("week")]
    Week,
}
