using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.HostPool;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SSOSecretTypeConstant
{
    [Description("Certificate")]
    Certificate,

    [Description("CertificateInKeyVault")]
    CertificateInKeyVault,

    [Description("SharedKey")]
    SharedKey,

    [Description("SharedKeyInKeyVault")]
    SharedKeyInKeyVault,
}
