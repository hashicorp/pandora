using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.Cache;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TemplateNameConstant
{
    [Description("accountClosedDeveloper")]
    AccountClosedDeveloper,

    [Description("applicationApprovedNotificationMessage")]
    ApplicationApprovedNotificationMessage,

    [Description("confirmSignUpIdentityDefault")]
    ConfirmSignUpIdentityDefault,

    [Description("emailChangeIdentityDefault")]
    EmailChangeIdentityDefault,

    [Description("inviteUserNotificationMessage")]
    InviteUserNotificationMessage,

    [Description("newCommentNotificationMessage")]
    NewCommentNotificationMessage,

    [Description("newDeveloperNotificationMessage")]
    NewDeveloperNotificationMessage,

    [Description("newIssueNotificationMessage")]
    NewIssueNotificationMessage,

    [Description("passwordResetByAdminNotificationMessage")]
    PasswordResetByAdminNotificationMessage,

    [Description("passwordResetIdentityDefault")]
    PasswordResetIdentityDefault,

    [Description("purchaseDeveloperNotificationMessage")]
    PurchaseDeveloperNotificationMessage,

    [Description("quotaLimitApproachingDeveloperNotificationMessage")]
    QuotaLimitApproachingDeveloperNotificationMessage,

    [Description("rejectDeveloperNotificationMessage")]
    RejectDeveloperNotificationMessage,

    [Description("requestDeveloperNotificationMessage")]
    RequestDeveloperNotificationMessage,
}
