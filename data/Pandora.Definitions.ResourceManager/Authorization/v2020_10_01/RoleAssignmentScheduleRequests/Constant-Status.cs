using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Authorization.v2020_10_01.RoleAssignmentScheduleRequests;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StatusConstant
{
    [Description("Accepted")]
    Accepted,

    [Description("AdminApproved")]
    AdminApproved,

    [Description("AdminDenied")]
    AdminDenied,

    [Description("Canceled")]
    Canceled,

    [Description("Denied")]
    Denied,

    [Description("Failed")]
    Failed,

    [Description("FailedAsResourceIsLocked")]
    FailedAsResourceIsLocked,

    [Description("Granted")]
    Granted,

    [Description("Invalid")]
    Invalid,

    [Description("PendingAdminDecision")]
    PendingAdminDecision,

    [Description("PendingApproval")]
    PendingApproval,

    [Description("PendingApprovalProvisioning")]
    PendingApprovalProvisioning,

    [Description("PendingEvaluation")]
    PendingEvaluation,

    [Description("PendingExternalProvisioning")]
    PendingExternalProvisioning,

    [Description("PendingProvisioning")]
    PendingProvisioning,

    [Description("PendingRevocation")]
    PendingRevocation,

    [Description("PendingScheduleCreation")]
    PendingScheduleCreation,

    [Description("Provisioned")]
    Provisioned,

    [Description("ProvisioningStarted")]
    ProvisioningStarted,

    [Description("Revoked")]
    Revoked,

    [Description("ScheduleCreated")]
    ScheduleCreated,

    [Description("TimedOut")]
    TimedOut,
}
