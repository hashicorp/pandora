using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.ExpressRouteCircuits;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExpressRouteCircuitSkuTierConstant
{
    [Description("Basic")]
    Basic,

    [Description("Local")]
    Local,

    [Description("Premium")]
    Premium,

    [Description("Standard")]
    Standard,
}
