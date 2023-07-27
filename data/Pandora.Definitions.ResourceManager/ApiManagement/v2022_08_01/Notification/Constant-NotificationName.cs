using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.Notification;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NotificationNameConstant
{
    [Description("AccountClosedPublisher")]
    AccountClosedPublisher,

    [Description("BCC")]
    BCC,

    [Description("NewApplicationNotificationMessage")]
    NewApplicationNotificationMessage,

    [Description("NewIssuePublisherNotificationMessage")]
    NewIssuePublisherNotificationMessage,

    [Description("PurchasePublisherNotificationMessage")]
    PurchasePublisherNotificationMessage,

    [Description("QuotaLimitApproachingPublisherNotificationMessage")]
    QuotaLimitApproachingPublisherNotificationMessage,

    [Description("RequestPublisherNotificationMessage")]
    RequestPublisherNotificationMessage,
}
