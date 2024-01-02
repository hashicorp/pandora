using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.P2sVpnGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VnetLocalRouteOverrideCriteriaConstant
{
    [Description("Contains")]
    Contains,

    [Description("Equal")]
    Equal,
}
