using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_08_01.Budgets;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ThresholdTypeConstant
{
    [Description("Actual")]
    Actual,

    [Description("Forecasted")]
    Forecasted,
}
