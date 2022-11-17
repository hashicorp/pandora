using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.UsageDetails;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PricingModelTypeConstant
{
    [Description("On Demand")]
    OnDemand,

    [Description("Reservation")]
    Reservation,

    [Description("Spot")]
    Spot,
}
