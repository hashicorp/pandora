using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.P2SVpnGateways;

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
