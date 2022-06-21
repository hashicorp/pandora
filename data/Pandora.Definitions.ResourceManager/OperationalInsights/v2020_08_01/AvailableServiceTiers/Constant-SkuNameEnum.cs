using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2020_08_01.AvailableServiceTiers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuNameEnumConstant
{
    [Description("CapacityReservation")]
    CapacityReservation,

    [Description("Free")]
    Free,

    [Description("PerGB2018")]
    PerGBTwoZeroOneEight,

    [Description("PerNode")]
    PerNode,

    [Description("Premium")]
    Premium,

    [Description("Standalone")]
    Standalone,

    [Description("Standard")]
    Standard,
}
