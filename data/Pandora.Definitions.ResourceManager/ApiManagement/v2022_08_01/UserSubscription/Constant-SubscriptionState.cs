using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.UserSubscription;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SubscriptionStateConstant
{
    [Description("active")]
    Active,

    [Description("cancelled")]
    Cancelled,

    [Description("expired")]
    Expired,

    [Description("rejected")]
    Rejected,

    [Description("submitted")]
    Submitted,

    [Description("suspended")]
    Suspended,
}
