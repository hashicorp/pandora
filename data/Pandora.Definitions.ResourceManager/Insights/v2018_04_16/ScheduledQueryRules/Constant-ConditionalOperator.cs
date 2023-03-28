using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2018_04_16.ScheduledQueryRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConditionalOperatorConstant
{
    [Description("Equal")]
    Equal,

    [Description("GreaterThan")]
    GreaterThan,

    [Description("GreaterThanOrEqual")]
    GreaterThanOrEqual,

    [Description("LessThan")]
    LessThan,

    [Description("LessThanOrEqual")]
    LessThanOrEqual,
}
