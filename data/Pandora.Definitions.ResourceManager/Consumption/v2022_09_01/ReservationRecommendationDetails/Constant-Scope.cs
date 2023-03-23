using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2022_09_01.ReservationRecommendationDetails;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScopeConstant
{
    [Description("Shared")]
    Shared,

    [Description("Single")]
    Single,
}
