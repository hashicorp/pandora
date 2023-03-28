using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2018_04_16.ScheduledQueryRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertSeverityConstant
{
    [Description("4")]
    Four,

    [Description("1")]
    One,

    [Description("3")]
    Three,

    [Description("2")]
    Two,

    [Description("0")]
    Zero,
}
