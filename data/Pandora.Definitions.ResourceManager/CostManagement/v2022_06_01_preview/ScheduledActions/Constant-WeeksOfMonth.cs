using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_06_01_preview.ScheduledActions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WeeksOfMonthConstant
{
    [Description("First")]
    First,

    [Description("Fourth")]
    Fourth,

    [Description("Last")]
    Last,

    [Description("Second")]
    Second,

    [Description("Third")]
    Third,
}
