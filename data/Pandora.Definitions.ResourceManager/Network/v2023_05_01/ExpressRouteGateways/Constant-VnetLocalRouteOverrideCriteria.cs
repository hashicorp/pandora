using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_05_01.ExpressRouteGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VnetLocalRouteOverrideCriteriaConstant
{
    [Description("Contains")]
    Contains,

    [Description("Equal")]
    Equal,
}
