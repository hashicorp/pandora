using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataDog.v2021_03_01.MonitorsResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MarketplaceSubscriptionStatusConstant
{
    [Description("Active")]
    Active,

    [Description("Provisioning")]
    Provisioning,

    [Description("Suspended")]
    Suspended,

    [Description("Unsubscribed")]
    Unsubscribed,
}
