using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01.Forecasts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BoundConstant
{
    [Description("Lower")]
    Lower,

    [Description("Upper")]
    Upper,
}
