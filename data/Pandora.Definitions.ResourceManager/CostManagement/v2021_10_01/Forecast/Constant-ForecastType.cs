using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Forecast;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ForecastTypeConstant
{
    [Description("ActualCost")]
    ActualCost,

    [Description("AmortizedCost")]
    AmortizedCost,

    [Description("Usage")]
    Usage,
}
