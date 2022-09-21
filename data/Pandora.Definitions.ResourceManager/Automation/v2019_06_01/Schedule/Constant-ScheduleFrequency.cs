using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScheduleFrequencyConstant
{
    [Description("Day")]
    Day,

    [Description("Hour")]
    Hour,

    [Description("Minute")]
    Minute,

    [Description("Month")]
    Month,

    [Description("OneTime")]
    OneTime,

    [Description("Week")]
    Week,
}
