using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2023_05_01.Lots;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LotSourceConstant
{
    [Description("ConsumptionCommitment")]
    ConsumptionCommitment,

    [Description("PromotionalCredit")]
    PromotionalCredit,

    [Description("PurchasedCredit")]
    PurchasedCredit,
}
