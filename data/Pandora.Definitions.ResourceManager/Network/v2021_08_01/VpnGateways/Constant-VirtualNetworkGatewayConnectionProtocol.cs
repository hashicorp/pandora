using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.VpnGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualNetworkGatewayConnectionProtocolConstant
{
    [Description("IKEv1")]
    IKEvOne,

    [Description("IKEv2")]
    IKEvTwo,
}
