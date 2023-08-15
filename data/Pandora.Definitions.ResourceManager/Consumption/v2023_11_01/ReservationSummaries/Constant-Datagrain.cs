using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2023_11_01.ReservationSummaries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DatagrainConstant
{
    [Description("daily")]
    Daily,

    [Description("monthly")]
    Monthly,
}
