using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.FrontDoors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CustomHTTPSProvisioningSubstateConstant
{
    [Description("CertificateDeleted")]
    CertificateDeleted,

    [Description("CertificateDeployed")]
    CertificateDeployed,

    [Description("DeletingCertificate")]
    DeletingCertificate,

    [Description("DeployingCertificate")]
    DeployingCertificate,

    [Description("DomainControlValidationRequestApproved")]
    DomainControlValidationRequestApproved,

    [Description("DomainControlValidationRequestRejected")]
    DomainControlValidationRequestRejected,

    [Description("DomainControlValidationRequestTimedOut")]
    DomainControlValidationRequestTimedOut,

    [Description("IssuingCertificate")]
    IssuingCertificate,

    [Description("PendingDomainControlValidationREquestApproval")]
    PendingDomainControlValidationREquestApproval,

    [Description("SubmittingDomainControlValidationRequest")]
    SubmittingDomainControlValidationRequest,
}
