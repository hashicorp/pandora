using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.VirtualNetworkGatewayConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VpnNatRuleTypeConstant
{
    [Description("Dynamic")]
    Dynamic,

    [Description("Static")]
    Static,
}
