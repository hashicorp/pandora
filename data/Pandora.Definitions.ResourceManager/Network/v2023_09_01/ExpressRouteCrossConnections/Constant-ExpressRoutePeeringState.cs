using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.ExpressRouteCrossConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExpressRoutePeeringStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
