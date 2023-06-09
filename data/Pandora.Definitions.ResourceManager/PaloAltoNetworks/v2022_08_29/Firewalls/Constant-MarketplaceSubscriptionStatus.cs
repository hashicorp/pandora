using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.Firewalls;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MarketplaceSubscriptionStatusConstant
{
    [Description("FulfillmentRequested")]
    FulfillmentRequested,

    [Description("NotStarted")]
    NotStarted,

    [Description("PendingFulfillmentStart")]
    PendingFulfillmentStart,

    [Description("Subscribed")]
    Subscribed,

    [Description("Suspended")]
    Suspended,

    [Description("Unsubscribed")]
    Unsubscribed,
}
