using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.ScheduledActions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScheduleFrequencyConstant
{
    [Description("Daily")]
    Daily,

    [Description("Monthly")]
    Monthly,

    [Description("Weekly")]
    Weekly,
}
