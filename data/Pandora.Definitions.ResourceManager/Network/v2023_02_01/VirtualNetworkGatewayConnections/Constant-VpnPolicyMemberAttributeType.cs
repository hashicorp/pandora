using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.VirtualNetworkGatewayConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VpnPolicyMemberAttributeTypeConstant
{
    [Description("AADGroupId")]
    AADGroupId,

    [Description("CertificateGroupId")]
    CertificateGroupId,

    [Description("RadiusAzureGroupId")]
    RadiusAzureGroupId,
}
