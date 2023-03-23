using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2022_09_01.ReservationSummaries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DatagrainConstant
{
    [Description("daily")]
    Daily,

    [Description("monthly")]
    Monthly,
}
