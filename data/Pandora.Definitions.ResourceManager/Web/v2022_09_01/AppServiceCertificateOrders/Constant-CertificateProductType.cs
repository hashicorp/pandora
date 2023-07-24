using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.AppServiceCertificateOrders;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CertificateProductTypeConstant
{
    [Description("StandardDomainValidatedSsl")]
    StandardDomainValidatedSsl,

    [Description("StandardDomainValidatedWildCardSsl")]
    StandardDomainValidatedWildCardSsl,
}
