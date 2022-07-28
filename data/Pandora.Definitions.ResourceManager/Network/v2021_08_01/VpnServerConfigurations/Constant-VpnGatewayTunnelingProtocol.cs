using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.VpnServerConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VpnGatewayTunnelingProtocolConstant
{
    [Description("IkeV2")]
    IkeVTwo,

    [Description("OpenVPN")]
    OpenVPN,
}
