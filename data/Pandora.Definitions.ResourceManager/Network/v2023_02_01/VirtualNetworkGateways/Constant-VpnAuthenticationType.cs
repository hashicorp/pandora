using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.VirtualNetworkGateways;

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
