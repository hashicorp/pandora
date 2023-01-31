using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DeviceProvisioningServices.v2022_12_12.DpsCertificate;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CertificatePurposeConstant
{
    [Description("clientAuthentication")]
    ClientAuthentication,

    [Description("serverAuthentication")]
    ServerAuthentication,
}
