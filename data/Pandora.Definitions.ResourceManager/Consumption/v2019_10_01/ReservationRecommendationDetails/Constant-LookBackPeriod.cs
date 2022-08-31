using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01.ReservationRecommendationDetails;

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
