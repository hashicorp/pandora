using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.BenefitRecommendations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LookBackPeriodConstant
{
    [Description("Last7Days")]
    LastSevenDays,

    [Description("Last60Days")]
    LastSixZeroDays,

    [Description("Last30Days")]
    LastThreeZeroDays,
}
