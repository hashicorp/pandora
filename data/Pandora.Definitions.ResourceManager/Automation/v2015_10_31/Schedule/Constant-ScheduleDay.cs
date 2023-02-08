using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2015_10_31.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScheduleDayConstant
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
