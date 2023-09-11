using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.PerformConnectivityCheck;

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
