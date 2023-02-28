using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_01_02_preview.MaintenanceConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WeekDayConstant
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
