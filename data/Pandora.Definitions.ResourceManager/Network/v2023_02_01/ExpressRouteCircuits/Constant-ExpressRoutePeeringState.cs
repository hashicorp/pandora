using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.ExpressRouteCircuits;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExpressRoutePeeringStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
