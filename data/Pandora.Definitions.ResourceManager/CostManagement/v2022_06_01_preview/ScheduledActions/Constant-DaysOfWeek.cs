using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_06_01_preview.ScheduledActions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DaysOfWeekConstant
{
    [Description("Friday")]
    Friday,

    [Description("Monday")]
    Monday,

    [Description("Saturday")]
    Saturday,

    [Description("Sunday")]
    Sunday,

    [Description("Thursday")]
    Thursday,

    [Description("Tuesday")]
    Tuesday,

    [Description("Wednesday")]
    Wednesday,
}
