using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2023_11_01.ReservationRecommendations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReservationRecommendationKindConstant
{
    [Description("legacy")]
    Legacy,

    [Description("modern")]
    Modern,
}
