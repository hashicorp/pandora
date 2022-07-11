using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2021_08_01.ScheduledQueryRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConditionOperatorConstant
{
    [Description("Equals")]
    Equals,

    [Description("GreaterThan")]
    GreaterThan,

    [Description("GreaterThanOrEqual")]
    GreaterThanOrEqual,

    [Description("LessThan")]
    LessThan,

    [Description("LessThanOrEqual")]
    LessThanOrEqual,
}
