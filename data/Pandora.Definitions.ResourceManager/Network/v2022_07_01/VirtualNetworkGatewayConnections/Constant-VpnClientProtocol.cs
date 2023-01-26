using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualNetworkGatewayConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VpnClientProtocolConstant
{
    [Description("IkeV2")]
    IkeVTwo,

    [Description("OpenVPN")]
    OpenVPN,

    [Description("SSTP")]
    SSTP,
}
