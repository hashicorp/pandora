using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.RouteFilters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CircuitConnectionStatusConstant
{
    [Description("Connected")]
    Connected,

    [Description("Connecting")]
    Connecting,

    [Description("Disconnected")]
    Disconnected,
}
