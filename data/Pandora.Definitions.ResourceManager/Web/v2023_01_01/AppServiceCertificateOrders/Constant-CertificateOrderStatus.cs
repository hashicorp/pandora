using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.AppServiceCertificateOrders;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CertificateOrderStatusConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Denied")]
    Denied,

    [Description("Expired")]
    Expired,

    [Description("Issued")]
    Issued,

    [Description("NotSubmitted")]
    NotSubmitted,

    [Description("PendingRekey")]
    PendingRekey,

    [Description("Pendingissuance")]
    Pendingissuance,

    [Description("Pendingrevocation")]
    Pendingrevocation,

    [Description("Revoked")]
    Revoked,

    [Description("Unused")]
    Unused,
}
