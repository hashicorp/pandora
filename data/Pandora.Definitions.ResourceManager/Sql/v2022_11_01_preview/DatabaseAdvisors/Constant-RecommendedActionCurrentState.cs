using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.DatabaseAdvisors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecommendedActionCurrentStateConstant
{
    [Description("Active")]
    Active,

    [Description("Error")]
    Error,

    [Description("Executing")]
    Executing,

    [Description("Expired")]
    Expired,

    [Description("Ignored")]
    Ignored,

    [Description("Monitoring")]
    Monitoring,

    [Description("Pending")]
    Pending,

    [Description("PendingRevert")]
    PendingRevert,

    [Description("Resolved")]
    Resolved,

    [Description("RevertCancelled")]
    RevertCancelled,

    [Description("Reverted")]
    Reverted,

    [Description("Reverting")]
    Reverting,

    [Description("Success")]
    Success,

    [Description("Verifying")]
    Verifying,
}
