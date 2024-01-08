using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.ExpressRouteCrossConnectionPeerings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExpressRouteCircuitPeeringStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
