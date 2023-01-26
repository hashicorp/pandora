using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ExpressRoutePorts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExpressRoutePortsEncapsulationConstant
{
    [Description("Dot1Q")]
    DotOneQ,

    [Description("QinQ")]
    QinQ,
}
