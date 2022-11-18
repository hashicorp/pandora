using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.SessionHost;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HealthCheckResultConstant
{
    [Description("HealthCheckFailed")]
    HealthCheckFailed,

    [Description("HealthCheckSucceeded")]
    HealthCheckSucceeded,

    [Description("SessionHostShutdown")]
    SessionHostShutdown,

    [Description("Unknown")]
    Unknown,
}
