using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.ExpressRouteCircuitPeerings;

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
