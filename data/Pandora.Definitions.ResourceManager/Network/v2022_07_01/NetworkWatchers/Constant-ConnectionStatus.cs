using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkWatchers;

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
