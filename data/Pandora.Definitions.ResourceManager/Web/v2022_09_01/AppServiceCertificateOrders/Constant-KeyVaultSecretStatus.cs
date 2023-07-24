using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.AppServiceCertificateOrders;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KeyVaultSecretStatusConstant
{
    [Description("AzureServiceUnauthorizedToAccessKeyVault")]
    AzureServiceUnauthorizedToAccessKeyVault,

    [Description("CertificateOrderFailed")]
    CertificateOrderFailed,

    [Description("ExternalPrivateKey")]
    ExternalPrivateKey,

    [Description("Initialized")]
    Initialized,

    [Description("KeyVaultDoesNotExist")]
    KeyVaultDoesNotExist,

    [Description("KeyVaultSecretDoesNotExist")]
    KeyVaultSecretDoesNotExist,

    [Description("OperationNotPermittedOnKeyVault")]
    OperationNotPermittedOnKeyVault,

    [Description("Succeeded")]
    Succeeded,

    [Description("Unknown")]
    Unknown,

    [Description("UnknownError")]
    UnknownError,

    [Description("WaitingOnCertificateOrder")]
    WaitingOnCertificateOrder,
}
