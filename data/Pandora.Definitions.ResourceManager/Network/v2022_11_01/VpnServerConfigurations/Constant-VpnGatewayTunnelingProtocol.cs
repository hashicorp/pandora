using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_11_01.VpnServerConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VpnGatewayTunnelingProtocolConstant
{
    [Description("IkeV2")]
    IkeVTwo,

    [Description("OpenVPN")]
    OpenVPN,
}
