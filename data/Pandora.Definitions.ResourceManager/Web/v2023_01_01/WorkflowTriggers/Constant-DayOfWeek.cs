using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WorkflowTriggers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DayOfWeekConstant
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
