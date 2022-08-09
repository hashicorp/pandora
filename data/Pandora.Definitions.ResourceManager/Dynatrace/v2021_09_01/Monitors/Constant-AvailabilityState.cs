using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Dynatrace.v2021_09_01.Monitors;

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
