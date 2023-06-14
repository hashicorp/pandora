using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.ApplicationGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGatewayBackendHealthServerHealthConstant
{
    [Description("Down")]
    Down,

    [Description("Draining")]
    Draining,

    [Description("Partial")]
    Partial,

    [Description("Unknown")]
    Unknown,

    [Description("Up")]
    Up,
}
