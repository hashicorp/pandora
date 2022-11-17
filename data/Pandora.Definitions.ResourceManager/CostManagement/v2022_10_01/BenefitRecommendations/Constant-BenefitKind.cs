using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.BenefitRecommendations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BenefitKindConstant
{
    [Description("IncludedQuantity")]
    IncludedQuantity,

    [Description("Reservation")]
    Reservation,

    [Description("SavingsPlan")]
    SavingsPlan,
}
