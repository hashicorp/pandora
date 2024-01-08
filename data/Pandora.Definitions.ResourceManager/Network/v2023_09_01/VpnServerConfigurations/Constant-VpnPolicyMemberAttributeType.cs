using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.VpnServerConfigurations;

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
