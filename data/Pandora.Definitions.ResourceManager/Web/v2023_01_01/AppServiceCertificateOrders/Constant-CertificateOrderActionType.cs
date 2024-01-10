using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.AppServiceCertificateOrders;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CertificateOrderActionTypeConstant
{
    [Description("CertificateExpirationWarning")]
    CertificateExpirationWarning,

    [Description("CertificateExpired")]
    CertificateExpired,

    [Description("CertificateIssued")]
    CertificateIssued,

    [Description("CertificateOrderCanceled")]
    CertificateOrderCanceled,

    [Description("CertificateOrderCreated")]
    CertificateOrderCreated,

    [Description("CertificateRevoked")]
    CertificateRevoked,

    [Description("DomainValidationComplete")]
    DomainValidationComplete,

    [Description("FraudCleared")]
    FraudCleared,

    [Description("FraudDetected")]
    FraudDetected,

    [Description("FraudDocumentationRequired")]
    FraudDocumentationRequired,

    [Description("OrgNameChange")]
    OrgNameChange,

    [Description("OrgValidationComplete")]
    OrgValidationComplete,

    [Description("SanDrop")]
    SanDrop,

    [Description("Unknown")]
    Unknown,
}
