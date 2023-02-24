using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logz.v2020_10_01.Monitors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MarketplaceSubscriptionStatusConstant
{
    [Description("Active")]
    Active,

    [Description("Suspended")]
    Suspended,
}
