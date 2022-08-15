using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01.Lots;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LotSourceConstant
{
    [Description("PromotionalCredit")]
    PromotionalCredit,

    [Description("PurchasedCredit")]
    PurchasedCredit,
}
