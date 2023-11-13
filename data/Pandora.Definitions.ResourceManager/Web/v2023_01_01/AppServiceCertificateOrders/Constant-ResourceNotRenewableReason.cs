using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.AppServiceCertificateOrders;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResourceNotRenewableReasonConstant
{
    [Description("ExpirationNotInRenewalTimeRange")]
    ExpirationNotInRenewalTimeRange,

    [Description("RegistrationStatusNotSupportedForRenewal")]
    RegistrationStatusNotSupportedForRenewal,

    [Description("SubscriptionNotActive")]
    SubscriptionNotActive,
}
