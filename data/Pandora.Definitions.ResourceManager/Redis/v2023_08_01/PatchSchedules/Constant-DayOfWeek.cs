using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Redis.v2023_08_01.PatchSchedules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DayOfWeekConstant
{
    [Description("Everyday")]
    Everyday,

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

    [Description("Weekend")]
    Weekend,
}
