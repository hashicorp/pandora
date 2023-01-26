using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ExpressRouteCircuits;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExpressRouteCircuitSkuFamilyConstant
{
    [Description("MeteredData")]
    MeteredData,

    [Description("UnlimitedData")]
    UnlimitedData,
}
