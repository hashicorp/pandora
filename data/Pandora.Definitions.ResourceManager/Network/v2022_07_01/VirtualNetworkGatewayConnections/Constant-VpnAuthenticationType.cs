using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualNetworkGatewayConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VpnAuthenticationTypeConstant
{
    [Description("AAD")]
    AAD,

    [Description("Certificate")]
    Certificate,

    [Description("Radius")]
    Radius,
}
