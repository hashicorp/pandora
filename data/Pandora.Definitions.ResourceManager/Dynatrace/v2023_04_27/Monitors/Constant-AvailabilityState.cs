using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Dynatrace.v2023_04_27.Monitors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AvailabilityStateConstant
{
    [Description("CRASHED")]
    CRASHED,

    [Description("LOST")]
    LOST,

    [Description("MONITORED")]
    MONITORED,

    [Description("PRE_MONITORED")]
    PREMONITORED,

    [Description("SHUTDOWN")]
    SHUTDOWN,

    [Description("UNEXPECTED_SHUTDOWN")]
    UNEXPECTEDSHUTDOWN,

    [Description("UNKNOWN")]
    UNKNOWN,

    [Description("UNMONITORED")]
    UNMONITORED,
}
