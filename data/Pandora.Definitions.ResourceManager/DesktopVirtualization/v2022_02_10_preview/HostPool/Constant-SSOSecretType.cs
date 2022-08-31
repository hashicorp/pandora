using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_02_10_preview.HostPool;

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
