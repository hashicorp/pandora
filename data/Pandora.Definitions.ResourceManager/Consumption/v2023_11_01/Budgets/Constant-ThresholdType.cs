using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2023_11_01.Budgets;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ThresholdTypeConstant
{
    [Description("Actual")]
    Actual,

    [Description("Forecasted")]
    Forecasted,
}
