using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Subscription.v2021_10_01.Subscriptions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AcceptOwnershipConstant
{
    [Description("Completed")]
    Completed,

    [Description("Expired")]
    Expired,

    [Description("Pending")]
    Pending,
}
