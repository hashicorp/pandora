using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.PerformConnectivityCheck;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConnectionStatusConstant
{
    [Description("Connected")]
    Connected,

    [Description("Degraded")]
    Degraded,

    [Description("Disconnected")]
    Disconnected,

    [Description("Unknown")]
    Unknown,
}
