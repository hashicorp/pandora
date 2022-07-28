using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.VirtualNetworkGateways;

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
